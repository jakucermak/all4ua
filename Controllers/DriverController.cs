using Microsoft.AspNetCore.Mvc;
using Refugee.Models.Entities;
using Refugee.Services;
using Refugee.ViewModels;

namespace Refugee.Controllers;

[Route("{controller}")]
public class DriverController: Controller
{
    private DriverService DriverService { get; }

    public DriverController(DriverService driverService)
    {
        DriverService = driverService;
    }

    [HttpPost]
    public IActionResult CreateDriver([FromBody] DriverViewModel driver)
    {
        try
        {
            DriverService.CreateDriver(driver);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
        return Ok(new { message = "ok" });
    }

    [HttpGet("{uuid}")]
    public IActionResult GetByDriverId(Guid uuid)
    {
        Driver? driver = DriverService.GetDriverByUuid(uuid) ;
        if (driver is not null)
        {
            var driverViewModel = new DriverViewModel
            {
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Email = driver.Email,
                PhoneNumber = driver.PhoneNumber,
                AdultsAmount = driver.AdultsAmount,
                KidsAmount = driver.KidsAmount,
                PickupDestination = driver.PickupDestination,
                FinalDestination = driver.FinalDestination,
                DateCreated = driver.DateCreated,
                Provide = driver.Provide,
            };
            return Ok(driverViewModel);
        }
        return NotFound();
    }

    [HttpDelete("{uuid}")]
    public IActionResult DeleteDriver(Guid uuid)
    {
        try
        {
          DriverService.RemoveDriverByUuid(uuid);  
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound(new { message = "driver not found"});
        }
        return Ok(new { message = "ok" });
    }
}