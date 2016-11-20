using System;
using Xunit;
using Site.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Site.Services;
using Site.Models;

namespace Site.Tests.Controllers
{
    public class WinnerControllerTests
    {
        [Fact]
        public void Index_ReturnsIndexView() 
        {
            var mockWinningNameService = new Mock<IGetWinningNameService>();

            var expectedName = "Tester";
            var controller = new WinnerController();

            var result = controller.Index(expectedName) as ViewResult;
            Assert.NotNull(result);

            var returnedModel = result.Model as WinningNameModel;
            Assert.Equal(expectedName, returnedModel.Name); 
        }
    }
}
