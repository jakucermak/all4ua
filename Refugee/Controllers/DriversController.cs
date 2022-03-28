using Microsoft.AspNetCore.Mvc;
using Refugee.Models.Entities;
using Refugee.Services;

namespace Refugee.Controllers;
[Route("{controller}")]
public class DriversController : Controller
{
    private readonly IDriverService _driverService;
    private LocationService LocationService { get; }

    public DriversController(IDriverService driverService, LocationService locationService)
    {
        _driverService = driverService;
        LocationService = locationService;
    }
    
    
    [HttpGet]
    public IActionResult Index()
    {

        Driver[] drivers = _driverService.GetAllDrivers();

        var response = new
        {
            status = "ok",
            count = drivers.Length,
            drivers = drivers
        };
        return Ok(response);
    }
}