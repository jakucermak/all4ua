using Refugee.Database;
using Refugee.Models.Entities;

namespace Refugee.Services;

public class DriverService: IDriverService
{
    private ApplicationDbContext Context { get; set; }
    private LocationService LocationService { get; set; }
    
    public DriverService(ApplicationDbContext dbContext, LocationService locationService)
    {
        Context = dbContext;
        LocationService = locationService;
    }

    public void CreateDriver(Driver driver)
    {
        var uuid = Guid.NewGuid();
        Context.Drivers.Add(
            new Driver
            {
                Uuid = uuid,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Email = driver.Email,
                PhoneNumber = driver.PhoneNumber,
                AdultsAmount = driver.AdultsAmount,
                KidsAmount = driver.KidsAmount,
                PickupDestination = driver.PickupDestination,
                FinalDestination = driver.FinalDestination,
                DateCreated = DateTimeOffset.Now.ToUnixTimeSeconds(),
                Provide = driver.Provide
            }
            );
        Context.SaveChanges();

        Driver driverEntity = Context.Drivers.Single(d => d.Uuid == uuid);

        LocationService.CreateLocation(driverEntity,driver.Location.Latitude,
            driver.Location.Longitude);
    }

    public Driver[] GetAllDrivers()
    {
        return Context.Drivers.ToArray();
    }

    public Driver? GetDriverByUuid(Guid uuid)
    {
        Driver? driver = Context.Drivers.SingleOrDefault(d => d.Uuid == uuid);
        return driver;
    }

    public bool RemoveDriverByUuid(Guid uuid)
    {
        Driver? driverToRemove = Context.Drivers.SingleOrDefault(d => d.Uuid == uuid);
        if (driverToRemove is not null)
        {
            Context.Drivers.Remove(driverToRemove);
            Context.SaveChanges();
            return true;
        }
        return false;
    }
}