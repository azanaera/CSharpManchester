using FootBall.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace FootBall.Tests
{
    public class HomeControllerShould
    {
        private readonly HomeController _sut;
        const string matches = "Manchester United 1 Chelsea 0,Arsenal 1 Manchester United 1,Manchester United 3 Fulham 1,Liverpool 2 Manchester United 1,Swansea 2 Manchester United 4";

        public HomeControllerShould()
        {
            _sut = new HomeController();
        }
        [Fact]
        public void ReturnViewForIndex()
        {
            var result = _sut.Index();
            Assert.IsType<ViewResult>(result);
        }
        [Theory]
        [InlineData(matches)]
        public void BeTheSameViewAfterCalculateMatch(string matchess)
        {

            var cookieCollection = new RequestCookieCollection { };
            var response = new Mock<Microsoft.AspNetCore.Http.HttpResponse>();
            response.SetupGet(r => r.Cookies).Returns(cookieCollection);

            //var context = new Mock<HttpContextBase>();
            //context.SetupGet(x => x.Response).Returns(response.Object);

            var result = _sut.CalculateMatch(matchess);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CalculateMatch", viewResult.ViewName);

        }
    }
}
