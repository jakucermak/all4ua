using Refugee.Database;
using Refugee.Models.Entities;
using Refugee.ViewModels;

namespace Refugee.Services;

public class LocationService
{
    private ApplicationDbContext Context { get; set; }

    public LocationService(ApplicationDbContext context)
    {
        Context = context;
    }
    
    public void CreateLocation(Driver driver, double longitude, double latitude)
    {
        Context.Locations.Add( new Location
        {
            Uuid = Guid.NewGuid(),
            Longitude = longitude,
            Latitude = latitude,
            DriverId = driver.Id
        });
        
        Context.SaveChanges();
    }

    public Location? GetLocationById(int driverId)
    {
        return Context.Locations.SingleOrDefault(l => l.DriverId == driverId);
    }
}