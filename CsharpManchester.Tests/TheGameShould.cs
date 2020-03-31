﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using System.IO;

namespace CsharpManchester.Tests
{
    public class TheGameShould
    {
        string results = "Manchester United 1 Chelsea 0,Arsenal 1 Manchester United 1,Manchester United 3 Fulham 1,Liverpool 2 Manchester United 1,Swansea 2 Manchester United 4";
        const string path = @"..\..\..\TestData.txt";

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
        [InlineData(path, 3)]
        public void MockHaveTheSameWinResult(string path, int expected)
        {
            
            var mockLoadData = new Mock<ILoadData>();
            mockLoadData.Setup(x => x.FromTextFile(It.IsAny<string>()))
                .Returns(File.ReadAllText(path));

            var calculatedMatches = new CalculatedMatches(mockLoadData.Object,path);
            Team selectedTeam = calculatedMatches.GetResults("Manchester United");
            Assert.Equal(expected, selectedTeam.Wins);
        }
    }
}
