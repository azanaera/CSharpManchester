using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBall.Models
{
    public class Team
    { 
        private static int count;
        public Team()
        {
            count++;
            Id = count;
        }
        public int Id { get; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int GamesPlayed { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int TotalPoints { get =>  (Wins * 3) + Draws; }
    }
}
