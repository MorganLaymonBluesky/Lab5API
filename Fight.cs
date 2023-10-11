using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFCFightFinder
{
    public class Fight
    {
        public string date { get; set; }
        public string promotion { get; set; }
        public string Event { get; set; }
        public string main_or_prelim { get; set; }
        public string card_placement { get; set; }
        public string fighter_1 { get; set; }
        public string fighter_2 { get; set; }
        public string rematch { get; set; }
        public string winner { get; set; }
        public string method { get; set; }
        public string round { get; set; }
        public string time { get; set; }

        public Fight() 
        {
            date = string.Empty;
            promotion = string.Empty;
            Event = string.Empty;
            main_or_prelim = string.Empty;
            card_placement = string.Empty;
            fighter_1 = string.Empty;
            fighter_2 = string.Empty;
            rematch = string.Empty;
            winner = string.Empty;
            method = string.Empty;
            round = string.Empty;
            time = string.Empty;
        }

        public Fight(string fightDate, string promotion, string eventTitle, string mainOrPrelim, string cardPlace, string fighter1Name, string fighter2Name, string rematch, string winner, string methodOfVictory, string round, string endTime)
        {
            this.date = fightDate;
            this.promotion = promotion;
            this.Event = eventTitle;
            this.main_or_prelim = mainOrPrelim;
            this.card_placement = cardPlace;
            this.fighter_1 = fighter1Name;
            this.fighter_2 = fighter2Name;
            this.rematch = rematch;
            this.winner = winner;
            this.method = methodOfVictory;
            this.round = round;
            this.time = endTime;
        }

        public override string ToString()
        {
            string displayFight = string.Empty;
            displayFight += " ========= " + promotion + ": " + Event + " =========\n" + 
                            "Date of Fight: " + date + "\n" +
                            "Main Event or Prelim: " + main_or_prelim + "\n" +
                            "Place on Card: " + card_placement + "\n\n" +
                            "--  " + fighter_1 + "  vs.  " + fighter_2 + " " + rematch + "  --" + "\n\n" + 
                            "Winner: " + winner + "\n" + 
                            "Method of Victory: " + method + "\n" +
                            "Round: " + round + "\n" +
                            "Time: " + time + "\n";
            return displayFight;
        }
    }
}
