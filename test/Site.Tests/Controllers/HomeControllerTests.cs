using System;
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
        public void Index_ReturnsIndexView() 
        {
            var model = new HomeModel()
            {
                Title = "Tester from service"
            };
            var mockService = new Mock<IGetHomeModels>();
            mockService.Setup(service => service.GetHomeModel()).Returns(model);

            var expectedViewName = "Index";
            var controller = new HomeController(mockService.Object);;

            var result = controller.Index() as ViewResult;
            Assert.NotNull(result);

            var returnedModel = result.Model as HomeModel;
            Assert.Equal("Tester from service", returnedModel.Title); 
        }
    }
}
