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
            var contextMock = new Mock<HttpContext>();
            var sessionMock = Mock.Of<ISession>();
            sessionMock.SetString(nameof(matches), matches);
            contextMock
                .SetupGet(c => c.Session).Returns(sessionMock);
            _sut = new HomeController(new HttpContextAccessor { HttpContext = contextMock.Object });
            // Act
            var result = _sut.CalculateMatch(matches);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<List<Team>>(viewResult.Model);
            Assert.Equal("CalculateMatch", viewResult.ViewName);

        }
    }
}
