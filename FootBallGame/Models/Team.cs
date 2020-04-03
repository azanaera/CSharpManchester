using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallGame.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int GamesPlayed { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
    }
}
