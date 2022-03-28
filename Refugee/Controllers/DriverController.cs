using Microsoft.AspNetCore.Mvc;
using Refugee.Models.Entities;
using Refugee.Services;

namespace Refugee.Controllers;

[Route("{controller}")]
public class DriverController: ControllerBase
{
    private readonly IDriverService _driverService;
    private DriverModelValidation _modelValidation;


    public DriverController( IDriverService driverService1, DriverModelValidation modelValidation)
    {
        _driverService = driverService1;
        _modelValidation = modelValidation;
    }

    [HttpPost]
    public IActionResult CreateDriver([FromBody] Driver driver)
    {
        if (!_modelValidation.IsModelValid(driver))
        {
            var modelError = _modelValidation.ModelError(ModelState);

            return BadRequest(modelError);
        }
        return Ok(new { message = "ok", driver });
    }

    [HttpGet("{uuid}")]
    public IActionResult GetByDriverId(Guid uuid)
    {
        Driver? driver = _driverService.GetDriverByUuid(uuid) ;
        if (driver is not null)
        {
            return Ok(driver);
        }
        return NotFound();
    }

    [HttpDelete("{uuid}")]
    public IActionResult DeleteDriver(Guid uuid)
    {
        try
        {
          _driverService.RemoveDriverByUuid(uuid);  
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return NotFound(new { message = "driver not found"});
        }
        return Ok(new { message = "ok" });
    }
}