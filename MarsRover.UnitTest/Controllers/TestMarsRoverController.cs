using FluentAssertions;
using MarsRover.API.Controllers;
using MarsRover.API.Models;
using MarsRover.API.Services.Interfaces;
using MarsRover.UnitTest.Fixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace MarsRover.UnitTest.Controllers
{
    public class TestMarsRoverController
    {        
        [Theory]
        [InlineData("navcam")]
        public async Task Get_OnSuccess_ReturnsStatusCode200(string cameraName)
        {
            // Arrange
            var mockMarsRoverService = new Mock<IMarsRoverService>();
            mockMarsRoverService
                .Setup(service => service.GetImagesByCamera(cameraName))
                .ReturnsAsync(MarsRoverImageFixture.GetTestImages());            

            var cache = new ServiceCollection();
            cache.AddMemoryCache();
            var serviceProvider = cache.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();
            
            var sut = new MarsRoverController(mockMarsRoverService.Object, memoryCache);


            // Act
            var result = (OkObjectResult)await sut.GetImagesByCamera(cameraName);

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData("navcam")]
        public async Task Get_OnSuccess_ReturnsListOfImages(string cameraName)
        {
            // Arrange
            var mockMarsRoverService = new Mock<IMarsRoverService>();
            mockMarsRoverService
                .Setup(service => service.GetImagesByCamera(cameraName))
                .ReturnsAsync(MarsRoverImageFixture.GetTestImages());            

            var cache = new ServiceCollection();
            cache.AddMemoryCache();
            var serviceProvider = cache.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();            

            var sut = new MarsRoverController(mockMarsRoverService.Object, memoryCache);


            // Act
            var result = await sut.GetImagesByCamera(cameraName);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objResult = (OkObjectResult)result;
            objResult.Value.Should().BeOfType<List<Image>>();
        }

        [Theory]
        [InlineData("navcam")]
        public async Task Get_OnNoImagesFound_Return404(string cameraName)
        {
            // Arrange
            var mockMarsRoverService = new Mock<IMarsRoverService>();
            mockMarsRoverService
                .Setup(service => service.GetImagesByCamera(cameraName))
                .ReturnsAsync(new List<Image>());            

            var cache = new ServiceCollection();
            cache.AddMemoryCache();
            var serviceProvider = cache.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();            

            var sut = new MarsRoverController(mockMarsRoverService.Object, memoryCache);

            // Act
            var result = await sut.GetImagesByCamera(cameraName);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

    }
}
