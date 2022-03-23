using Refugee.Database;
using Refugee.Models.Entities;
using Refugee.ViewModels;

namespace Refugee.Services;

public class DriverService
{
    private ApplicationDbContext Context { get; set; }
    private LocationService LocationService { get; set; }
    
    public DriverService(ApplicationDbContext dbContext, LocationService locationService)
    {
        Context = dbContext;
        LocationService = locationService;
    }

    public void CreateDriver(DriverViewModel driverViewModel)
    {
        var uuid = Guid.NewGuid();
        Context.Drivers.Add(
            new Driver
            {
                Uuid = uuid,
                FirstName = driverViewModel.FirstName,
                LastName = driverViewModel.LastName,
                Email = driverViewModel.Email,
                PhoneNumber = driverViewModel.PhoneNumber,
                AdultsAmount = driverViewModel.AdultsAmount,
                KidsAmount = driverViewModel.KidsAmount,
                PickupDestination = driverViewModel.PickupDestination,
                FinalDestination = driverViewModel.FinalDestination,
                DateCreated = DateTimeOffset.Now.ToUnixTimeSeconds(),
                Provide = driverViewModel.Provide,
            }
            );
        Context.SaveChanges();

        Driver driver = Context.Drivers.Single(d => d.Uuid == uuid);

        LocationService.CreateLocation(driver,driverViewModel.Location.Latitude,
            driverViewModel.Location.Longitude);
        
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
    
    public List<DriverViewModel> DriverViewModels()
    {
        var driverViewModels = new List<DriverViewModel>();

        foreach (var driver in GetAllDrivers())
        {
            var locationViewModel = new LocationViewModel();
            var location = LocationService.GetLocationById(driver.Id);

            if (location is not null)
            {
                locationViewModel = new LocationViewModel
                {
                    Longitude = location.Longitude,
                    Latitude = location.Latitude
                };
            }

            DriverViewModel driverViewModel = new DriverViewModel
            {
                Uuid = driver.Uuid,
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
                Location = locationViewModel
            };

            driverViewModels.Add(driverViewModel);
        }

        return driverViewModels;
    }
}