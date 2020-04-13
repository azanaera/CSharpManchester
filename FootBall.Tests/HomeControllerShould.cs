using CsharpManchester;
using FootBall.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace FootBall.Tests
{
    public class HomeControllerShould
    {
        Mock<IHttpContextAccessor> mockHttp;
        DefaultHttpContext context;
        private HomeController _sut;
        const string matches = "Manchester United 1 Chelsea 0,Arsenal 1 Manchester United 1,Manchester United 3 Fulham 1,Liverpool 2 Manchester United 1,Swansea 2 Manchester United 4";
        public HomeControllerShould()
        {
            // Arrange
            mockHttp =  new Mock<IHttpContextAccessor>();
            context  =  new DefaultHttpContext();

        }
        [Fact]
        public void ReturnViewForIndex()
        {
            var result = _sut.Index();
            Assert.IsType<ViewResult>(result);
        }
        [Theory]
        [InlineData(matches)]
        public void BeTheSameViewAfterCalculateMatch(string matches)
        {
            context.Response.Cookies.Append(nameof(matches), matches);
            mockHttp.Setup(_ => _.HttpContext).Returns(context);

            // Act
            _sut = new HomeController(mockHttp.Object);
            var result = _sut.CalculateMatch(matches);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<List<Team>>(viewResult.Model);
            //Assert.Equal("CalculateMatch", viewResult.ViewName);

        }
    }
}
