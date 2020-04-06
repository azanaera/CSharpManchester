using FootBall.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FootBall.Tests
{
    public class UnitTest1
    {
        private readonly HomeController _sut;
        const string matches = "Manchester United 1 Chelsea 0,Arsenal 1 Manchester United 1,Manchester United 3 Fulham 1,Liverpool 2 Manchester United 1,Swansea 2 Manchester United 4";

        public UnitTest1()
        {
            _sut = new HomeController();
        }
        [Fact]
        public void ReturnViewForIndex()
        {
            var result = _sut.Index();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void VerifyIndexPageAfterCalculateMatch()
        {
            var result = _sut.CalculateMatch(matches);
            Assert.Equal(result.GetType(),_sut.Index().GetType());

        }
    }
}
