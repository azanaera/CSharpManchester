using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CsharpManchester.Tests
{
    public class TheGameShould
    {
        string results = "Manchester United 1 Chelsea 0,Arsenal 1 Manchester United 1,Manchester United 3 Fulham 1,Liverpool 2 Manchester United 1,Swansea 2 Manchester United 4";
        [Fact]
        public void HaveTheTeamsRegistered()
        {
            var calculateMatches = new CalculateMatches(results);
            Assert.True(calculateMatches.HasTeamsRegistered());
        }
    }
}
