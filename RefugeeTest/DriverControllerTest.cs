using System;
using Microsoft.AspNetCore.Mvc;
using Refugee.Controllers;
using Refugee.Models.Entities;
using Refugee.Services;
using Xunit;

namespace RefugeeTest;

public class DriverControllerTest
{
    private readonly IDriverService _driverService;
    private readonly DriverController _controller;
    private readonly DriverModelValidation _modelValidation;
    

    public DriverControllerTest()
    {
        _driverService = new TestableDriverService();
        _modelValidation = new DriverModelValidation();
        
        _controller = new DriverController(_driverService, _modelValidation);
    }

    [Fact]
    public void CreateNewDriverSuccessfully()
    {
        Driver driverViewModel = new Driver
        {
            Uuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
            FirstName = "Tommy",
            LastName = "Angelo",
            Email = "tommy@salieris.com",
            PhoneNumber = "+1234567890",
            AdultsAmount = 1,
            KidsAmount = 2,
            PickupDestination = "Prague",
            FinalDestination = "Lost Heaven",
            DateCreated = 1234567890,
            Provide = "guns",
            Location = new Location
            {
                Longitude = 10.1,
                Latitude = 10.0,
            }
        };

        var createdResponse = _controller.CreateDriver(driverViewModel) as OkObjectResult;
        Assert.Equal(200,createdResponse.StatusCode);
    }

    [Fact]
    public void CreateNewDriverNonCompleteData()
    {
        Driver missingFirstNameItem = new Driver
        {
            Uuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
            LastName = "Angelo",
            Email = "tommy@salieris.com",
            PhoneNumber = "+1234567890",
            AdultsAmount = 1,
            KidsAmount = 2,
            PickupDestination = "Prague",
            FinalDestination = "Lost Heaven",
            DateCreated = 1234567890,
            Provide = "guns",
            Location = new Location
            {
                Longitude = 10.1,
                Latitude = 10.0,
            }
        };
        
        _controller.ModelState.AddModelError("first_name", "required");

        var badResponse = _controller.CreateDriver(missingFirstNameItem);

        Assert.IsType<BadRequestObjectResult>(badResponse);

    }
}