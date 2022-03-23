using Microsoft.AspNetCore.Mvc;
using Refugee.Services;
using Refugee.ViewModels;

namespace Refugee.Controllers;
[Route("{controller}")]
public class DriversController : Controller
{
    private DriverService DriverService { get; }
    private LocationService LocationService { get; }

    public DriversController(DriverService driverService, LocationService locationService)
    {
        DriverService = driverService;
        LocationService = locationService;
    }
    
    
    [HttpGet]
    public IActionResult Index()
    {
        
        var driverViewModels = DriverService.DriverViewModels();

        var response = new
        {
            status = "ok",
            count = driverViewModels.Count,
            drivers = driverViewModels
        };
        return Ok(response);
    }
}