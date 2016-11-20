using System;
using System.Collections.Generic;
using Site.Services;
using Xunit;
using Moq;

namespace Site.Tests.Services
{
    public class WinningNameServiceTests
    {
        [Fact]
        public void GetWinningName_GivenASetOfNamesWithLineBreaks_ReturnsOneAtRandom()
        {
        //Given
            var expectedName = "expected name";
            var mockRandomService = new Mock<IGetRandomNumber>();
            var names = new List<string>(){expectedName, "another name"};

            mockRandomService.Setup(service => service.Get(names.Count)).Returns(names.Count);

            var winningNameService = new WinningNameService(mockRandomService.Object);

            var namesList = string.Join(Environment.NewLine, names);
        //When
            var winningName = winningNameService.GetWinningName(namesList);        
        //Then
            Assert.Equal(expectedName, winningName.Name);
        }
    }
}