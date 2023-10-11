# Major Issues with the Project: 

1 - Checking for Unsuccessful/Empty API Calls

I ran into an issue for a while that involved not being able to check whether or not the API was returning any actual data based on what was searched. I wanted my system to force a reentry of data if there was not an applicable fight in the API, so the capability to do this was necessary. The problem with actually implementing this has to do with the fact that I consistently struggled to find a way to return a string or list of strings from the API Call method, as the return type was of Task type. I researched several potential solutions (Including changing the return type to Task<List<string>> and Task<string>), but any form of implementation or alteration of the method's return type resulted in unsatisfactory results. In order to solve this, I ended up checking for the length of the JSON return to see if it was less than 50 characters, as 50 characters were not enough to hold any properly formatted or accurate data, so this would filter out all invalid or empty results.

2 - Pulling from List of JSON Objects and their Attributes

When I first viewed the JSON for my API, I immediately noticed that all of the data was housed within a list of JSON objects, which gave me errors throughout all of my initial attempts at pulling data. To account for this issue, I installed a NuGet package called NewtonSoft.JSON, which allowed for easy conversion of JSON lists into individual objects. Once I started using this package and its functions, my problem was able to be resolved, and I was able to call upon the JSON lists successfully.

3 - Cleaning Up the JSON (HTML Tags, Whitespaces, Other Invalid Data)

For whatever reason, pulling the JSON from my API always includes HTML data due to how the webpage chooses to display the code on the webpage. In addition to that, there were different whitespaces around the code that made it unavailable to read as well. To account for the removal of this, I used built-in C# methods to remove the HTML tags and whitespace from the string, which allowed my JSON code to be properly read and stored.

4 - Changing the Console Output Color of an Object from the ToString

This was only a small issue, but I wanted my output to be color-coordinated, which required the use of the Console.ForegroundColor method. Unfortunately, this method only works in the Program.cs file (Based on my research, anyway.), which meant that I could not include color changes in my ToString method. In order to account for this, I had to write out each element of the Object using WriteLines in the Program.cs file. This method looked disgusting and I felt gross by doing it that way, but it was the only way I could find to implement the colors the way I wanted.
