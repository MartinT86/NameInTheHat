using Xunit;
using Site.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Site.Services;
using Site.Models;

namespace Site.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Post_GivenNamesEntered_RedirectsToWinner() 
        {
            var expectedName = "beep";
            var winningModel = new WinningNameModel(expectedName);
            var mockWinningNameService = new Mock<IGetWinningNameService>();
            mockWinningNameService.Setup(x => x.GetWinningName(expectedName)).Returns(winningModel);

            var postedModel = new HomeModel()
            {
                EnteredNames = expectedName
            };
            var controller = new HomeController(mockWinningNameService.Object);

            var result = controller.Index(postedModel) as RedirectToActionResult;
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Winner", result.ControllerName);
            Assert.Equal(expectedName, result.RouteValues["name"]);
        }

        [Fact]
        public void Index_Post_GivenNoNamesEntered_RedirectsToHome() 
        {
            var mockWinningNameService = new Mock<IGetWinningNameService>();

            var postedModel = new HomeModel();
            var controller = new HomeController(mockWinningNameService.Object);

            var result = controller.Index(postedModel) as RedirectToActionResult;
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }
    }
}