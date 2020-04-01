using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using System.IO;

namespace CsharpManchester.Tests
{
    public class TheGameShould
    {
        const string results = "Manchester United 1 Chelsea 0,Arsenal 1 Manchester United 1,Manchester United 3 Fulham 1,Liverpool 2 Manchester United 1,Swansea 2 Manchester United 4";
        const string results2 = "Arsenal 2 Chelsea 0,Arsenal 3 Manchester United 2,Arsenal 2 Fulham 1,Liverpool 2 Arsenal 5,Swansea 2 Arsenal 2";
        [Fact]
        public void HaveTheTeamsRegistered()
        {
            var calculateMatches = new CalculatedMatches(results);
            Assert.True(calculateMatches.HasTeamsRegistered());
        }
        [Fact]
        public void NotHaveTheTeamsRegistered()
        {
            var calculateMatches = new CalculatedMatches(results);
            Assert.False(calculateMatches.HasTeamsRegistered());
        }

        [Theory]
        [InlineData(results, "Manchester United", 3)]
        [InlineData(results2,"Arsenal", 4)]
        public void HaveTheSameWinResult(string result, string teamName, int expected)
        {
            
            var mockLoadData = new Mock<ILoadData>();
            mockLoadData.Setup(x => x.FromTextFile(It.IsAny<string>()))
                .Returns(result);

            var calculatedMatches = new CalculatedMatches(mockLoadData.Object,results);
            Team selectedTeam = calculatedMatches.GetResults(teamName);
            Assert.Equal(expected, selectedTeam.Wins);
        }

        [Theory]
        [InlineData(results, "Manchester United", 10)]
        [InlineData(results2, "Arsenal", 14)]
        public void HaveTheSameGoalsScored(string result, string teamName, int expected)
        {
            
            var mockLoadData = new Mock<ILoadData>();
            mockLoadData.Setup(x => x.FromTextFile(It.IsAny<string>()))
                .Returns(result);

            var calculatedMatches = new CalculatedMatches(mockLoadData.Object,results);
            Team selectedTeam = calculatedMatches.GetResults(teamName);
            Assert.Equal(expected, selectedTeam.GoalsScored);
        }
    }
}
