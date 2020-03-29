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
        const string results = "Manchester United 1 Chelsea 0,Arsenal 1 Manchester United 1,Manchester United 3 Fulham 1,Liverpool 2 Manchester United 1,Swansea 2 Manchester United 4";
        private CalculateMatches CreateDefaultCalculateMatches(string results)
        {
            return new CalculateMatches(results);
        }

        [Theory]
        [InlineData(results,3)]
        public void HaveTheSameWinResult(string results,int expected)
        {
            var calculateMatches = CreateDefaultCalculateMatches(results);
            Team selectedTeam = calculateMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.Wins);
        }

        [Theory]
        [InlineData(results,1)]
        public void HaveTheSameDrawResult(string results,int expected)
        {
            var calculateMatches = CreateDefaultCalculateMatches(results);
            Team selectedTeam = calculateMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.Draws);
        }

        [Theory]
        [InlineData(results,1)]
        public void HaveTheSameLossesResult(string results,int expected)
        {
            var calculateMatches = CreateDefaultCalculateMatches(results);
            Team selectedTeam = calculateMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.Losses);
        }

        [Theory]
        [InlineData(results,10)]
        public void HaveTheSameGoalsScoredResult(string results,int expected)
        {
            var calculateMatches = CreateDefaultCalculateMatches(results);
            Team selectedTeam = calculateMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.GoalsScored);
        }

        [Theory]
        [InlineData(results,6)]
        public void HaveTheSameGoalsConcededResult(string results,int expected)
        {
            var calculateMatches = CreateDefaultCalculateMatches(results);
            Team selectedTeam = calculateMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.GoalsConceded);
        }

        [Theory]
        [InlineData(results,10)]
        public void HaveTheSameTotalPointsResult(string results,int expected)
        {
            var calculateMatches = CreateDefaultCalculateMatches(results);
            Team selectedTeam = calculateMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.GetPoints());
        }
    }
}
