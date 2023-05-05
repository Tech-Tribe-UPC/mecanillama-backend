using AutoMapper;
using FakeItEasy;
using Mecanillama.API.Services.Domain.Models;
using Mecanillama.API.Services.Domain.Services;
using Mecanillama.API.Services.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Mecanillama.API.Services.Resources;
using Moq;
using Mecanillama.API.Customers.Mapping;
using System.Net;
using Mecanillama.API.Services.Domain.Services.Communication;

namespace Mecanillama.API.Tests.Services.Controllers
{
    public class ServiceControllerTest
    {
        private readonly ServicesController _controller;
        private readonly Mock<IServiceService> serviceService;
        private readonly IMapper _mapper;

        public ServiceControllerTest()
        {
            serviceService = new Mock<IServiceService>();
            _mapper = new MapperConfiguration(cfg =>
            cfg.AddProfile(new ModelToResourceProfile())).CreateMapper();
            _controller = new ServicesController(serviceService.Object, _mapper);
        }
        [Fact]
        public void ServiceController_GetServices_ReturnOK()
        {
            //Arrange
            var servicesList = GetServicesData();
            serviceService.Setup(x => x.ListAsync()).ReturnsAsync(servicesList);

            //Act
            var result = _controller.GetAllAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<IEnumerable<ServiceResource>>>();
        }
        //[Fact]
        //public async Task PostAsync_WithValidResource_ReturnsOk()
        //{
        //    // Arrange
        //    var saveResource = new SaveServiceResource { Name = "Test Service", Description = "Test Description", Price = 50, Photos = "www.example.com", MechanicId=1 };

        //    // Act
        //    var actionResult = await _controller.PostAsync(saveResource);

        //    // Assert
        //    actionResult.Should().BeOfType<OkObjectResult>();

        //}


        private List<Service> GetServicesData()
        {
            List<Service> servicesData = new List<Service>
            {
                new Service
                {
                    Id = 1,
                    Name = "Oil Repair",
                    Description = "Oil will be changed",
                    Price = 50,
                    Photos = "no photos",
                    MechanicId = 1
                },
                new Service
                {
                    Id = 1,
                    Name = "Service example",
                    Description = "this is an example",
                    Price = 50,
                    Photos = "no photos",
                    MechanicId = 2
                },
                new Service
                {
                    Id = 1,
                    Name = "Third example",
                    Description = "this is another example",
                    Price = 50,
                    Photos = "no photos yet",
                    MechanicId = 3
                }
            };
            return servicesData;
        }

    }
}
