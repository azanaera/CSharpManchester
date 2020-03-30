using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CsharpManchester;
using Moq;

namespace CsharpManchester.Tests
{
    public class ManChesterUnitedShould
    {
        const string Season1Results = "Manchester United 1 Chelsea 0,Arsenal 1 Manchester United 1,Manchester United 3 Fulham 1,Liverpool 2 Manchester United 1,Swansea 2 Manchester United 4";
        const string Season2Results = "Manchester United 2 Chelsea 5, Arsenal 2 Manchester United 2,Manchester United 2 Fulham 4,Liverpool 2 Manchester United 3,Swansea 4 Manchester United 3";
        const string Season3Results = "Manchester United 4 Chelsea 2, Arsenal 3 Manchester United 5,Manchester United 2 Fulham 1,Liverpool 4 Manchester United 2,Swansea 3 Manchester United 5";
        private CalculatedMatches CreateDefaultCalculateMatches(string results)
        {
            return new CalculatedMatches(results);
        }

        [Theory]
        [InlineData(Season1Results,3)]
        [InlineData(Season2Results,1)]
        [InlineData(Season3Results,4)]
        public void HaveTheSameWinResult(string results,int expected)
        {
            var calculateMatches = CreateDefaultCalculateMatches(results);
            Team selectedTeam = calculateMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.Wins);
        }

        [Theory]
        [InlineData(Season1Results, 1)]
        public void HaveTheSameDrawResult(string results,int expected)
        {
            var calculateMatches = CreateDefaultCalculateMatches(results);
            Team selectedTeam = calculateMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.Draws);
        }

        [Theory]
        [InlineData(Season1Results, 1)]
        public void HaveTheSameLossesResult(string results,int expected)
        {
            var calculateMatches = CreateDefaultCalculateMatches(results);
            Team selectedTeam = calculateMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.Losses);
        }

        [Theory]
        [InlineData(Season1Results, 10)]
        public void HaveTheSameGoalsScoredResult(string results,int expected)
        {
            var calculateMatches = CreateDefaultCalculateMatches(results);
            Team selectedTeam = calculateMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.GoalsScored);
        }

        [Theory]
        [InlineData(Season1Results, 6)]
        public void HaveTheSameGoalsConcededResult(string results,int expected)
        {
            var calculateMatches = CreateDefaultCalculateMatches(results);
            Team selectedTeam = calculateMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.GoalsConceded);
        }

        [Theory]
        [InlineData(Season1Results, 10)]
        public void HaveTheSameTotalPointsResult(string results,int expected)
        {
            var calculateMatches = CreateDefaultCalculateMatches(results);
            Team selectedTeam = calculateMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.GetPoints());
        }
    }
}
