using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using Newtonsoft;
using Newtonsoft.Json;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;

namespace UFCFightFinder
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string[] fightVars = { "any", "any", "any" };
            string sortType = "";

            MainMenu();

            async void MainMenu()
            {
                bool passThrough = false;
                int userInput = 0;
                //var writer = new StringWriter();
                //var previous = Console.Out;
                //System.Timers.Timer timer = new System.Timers.Timer(4000);

                string[] fightVars = { "any", "any", "any" };
                Console.WriteLine("----- Morgan's UFC Fight Selection System (Using Fighting Tomatoes API) -----\n" +
                                  "-----------------------------------------------------------------------------\n\n" +
                                  "Please select a search option: \n\n" +
                                  "[1] Fighter Name\n" +
                                  "[2] Event Title/Number\n" +
                                  "[3] Year of Fight\n" +
                                  "[4] Multiple Filters\n" +
                                  "[5] Exit\n");
                var parseUserInput = Console.ReadLine();
                while (!Int32.TryParse(parseUserInput, out userInput) || userInput > 5 || userInput < 1)
                {
                    Console.WriteLine("Error: Invalid Input. Please Try Again.");
                    parseUserInput = Console.ReadLine();
                }
                userInput = Convert.ToInt32(parseUserInput);
                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        while (passThrough == false)
                        {
                            Console.WriteLine("Please enter a fighter's name: ");
                            fightVars[0] = Console.ReadLine();
                            FightCall(fightVars, userInput);
                            var exitCheck = Console.ReadLine();
                            if (exitCheck.ToUpper() == "EXIT")
                            {
                                passThrough = true;
                            }
                            else
                            {
                                passThrough = false;
                            }
                            Console.Clear();
                        }
                        MainMenu();
                        break;
                    case 2:
                        Console.Clear();
                        while (passThrough == false)
                        {
                            Console.WriteLine("Please enter an event's title or name: ");
                            fightVars[1] = Console.ReadLine();
                            FightCall(fightVars, userInput);
                            var exitCheck = Console.ReadLine();
                            if (exitCheck.ToUpper() == "EXIT")
                            {
                                passThrough = true;
                            }
                            else
                            {
                                passThrough = false;
                            }
                            Console.Clear();
                        }
                        MainMenu();
                        break;
                    case 3:
                        Console.Clear();
                        while (passThrough == false)
                        {
                            Console.WriteLine("Please enter a year: ");
                            fightVars[2] = Console.ReadLine();
                            FightCall(fightVars, userInput);
                            var exitCheck = Console.ReadLine();
                            if (exitCheck.ToUpper() == "EXIT")
                            {
                                passThrough = true;
                            }
                            else
                            {
                                passThrough = false;
                            }
                            Console.Clear();
                        }
                        MainMenu();
                        break;
                    case 4:
                        Console.Clear();
                        while (passThrough == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("For any categories you do not want to filter by, insert 'any'.", Console.ForegroundColor);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Please enter a fighter's name: ");
                            fightVars[0] = Console.ReadLine();
                            Console.WriteLine("Please enter an event's title or name: ");
                            fightVars[1] = Console.ReadLine();
                            Console.WriteLine("Please enter a year: ");
                            fightVars[2] = Console.ReadLine();
                            FightCall(fightVars, userInput);
                            var exitCheck = Console.ReadLine();
                            if (exitCheck.ToUpper() == "EXIT")
                            {
                                passThrough = true;
                            }
                            else
                            {
                                passThrough = false;
                            }
                            Console.Clear();
                        }
                        MainMenu();
                        break;
                    case 5:
                        Console.WriteLine("Thank you for using the program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Error: Unacceptable Option.");
                        break;
                }
            }

            static async Task FightCall(string[] fightVars, int sortType)
            {
                var client = new HttpClient();
                List<string> fightList = new List<string>();

                HttpResponseMessage response = await client.GetAsync($"https://fightingtomatoes.com/API/f56410ee85d34a4e0b10c69589930768dfcadd6a/any/any/{fightVars[0]}");

                if (sortType == 1)
                {
                    response = await client.GetAsync($"https://fightingtomatoes.com/API/f56410ee85d34a4e0b10c69589930768dfcadd6a/any/any/{fightVars[0]}");
                }
                else if (sortType == 2)
                {
                    response = await client.GetAsync($"https://fightingtomatoes.com/API/f56410ee85d34a4e0b10c69589930768dfcadd6a/any/{fightVars[1]}/any");
                }
                else if (sortType == 3)
                {
                    response = await client.GetAsync($"https://fightingtomatoes.com/API/f56410ee85d34a4e0b10c69589930768dfcadd6a/{fightVars[2]}/any/any");
                }
                else if (sortType == 4)
                {
                    response = await client.GetAsync($"https://fightingtomatoes.com/API/f56410ee85d34a4e0b10c69589930768dfcadd6a/{fightVars[2]}/{fightVars[1]}/{fightVars[0]}");
                }

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    json = RemoveHTMLTags(json);
                    json = json.Remove(0, 1);
                    if (json.Length > 50)
                    {
                        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                        List<Fight> fights = JsonConvert.DeserializeObject<List<Fight>>(json);
                        foreach (var item in fights)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("=========  " + item.promotion + ": " + item.Event + "   =========\n");
                            Console.ResetColor();
                            Console.WriteLine("Date of Fight: " + item.date + "\n" +
                                              "Main Event or Prelim: " + item.main_or_prelim + "\n" +
                                              "Place on Card: " + item.card_placement + "\n");
                            Console.Write("-- ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(item.fighter_1);
                            Console.ResetColor();
                            Console.Write("  vs.  ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(item.fighter_2);
                            Console.ResetColor();
                            Console.Write(" " + item.rematch + "  --" + "\n\n");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Winner: " + item.winner + "\n");
                            Console.ResetColor();
                            Console.WriteLine("Method of Victory: " + item.method + "\n" +
                                              "Round: " + item.round + "\n" +
                                              "Time: " + item.time + "\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: No entries exist. Please try again: ");
                    }
                }
                else
                {
                    Console.WriteLine("Error: API Call failed.");
                }
                Console.WriteLine("Insert 'Exit' to go to Main Menu, or insert anything else to perform another search.");

                string RemoveHTMLTags(string json)
                {
                    int index = json.IndexOf("<");
                    if (index >= 0)
                        json = json.Substring(0, index);
                    return json;
                }
            }
        }
    }
}