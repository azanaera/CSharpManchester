﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpManchester
{
    public class Team
    {
        public string Name { get; set; }
        public int Score { get; set; }


        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int GamesPlayed { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int GetPoints() { return (Wins * 3) + Draws; }
        public Team(){}

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[{0}]\n", Name);
            sb.AppendFormat("No. of Wins:\t {0}\n", Wins);
            sb.AppendFormat("No. of Draws:\t {0}\n", Draws);
            sb.AppendFormat("No. of Defeats:\t {0}\n", Losses);
            sb.AppendFormat("Goals Scored:\t {0}\n", GoalsScored);
            sb.AppendFormat("Goals Conceded:\t {0}\n", GoalsConceded);
            sb.AppendFormat("No. of Points:\t {0}\n", GetPoints());

            return sb.ToString();
        }
    }

}
