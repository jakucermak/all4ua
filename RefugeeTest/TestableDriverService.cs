using System;
using System.Collections.Generic;
using System.Linq;
using Refugee.Models.Entities;
using Refugee.Services;

namespace RefugeeTest;

public class TestableDriverService: IDriverService
{
    private readonly List<Driver> Drivers;
    private readonly List<Location> Locations;

    public TestableDriverService()
    {

        Locations = new List<Location>()
        {
            new Location
            {
                Id = 1,
                Uuid = Guid.Empty,
                Longitude = 10.0,
                Latitude = 10.0,
                DriverId = 1
            },
            new Location
            {
                Id = 2,
                Uuid = Guid.Empty,
                Longitude = 11.1,
                Latitude = 11.1,
                DriverId = 2
            }
        };
        
        
        
        Drivers = new List<Driver>
        {
            new Driver
            {
                Id = 1,
                Uuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john@Doe.com",
                PhoneNumber = "+1234567890",
                AdultsAmount = 1,
                KidsAmount = 1,
                PickupDestination = "Ostrava",
                FinalDestination = "Prague",
                DateCreated = 1234567890,
                Provide = "nothing",
                Location = Locations[0]
            },
            
            new Driver
            {
                Id = 2,
                Uuid = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                FirstName = "Jane",
                LastName = "Doew",
                Email = "jane@doe.com",
                PhoneNumber = "+0987654321",
                AdultsAmount = 3,
                KidsAmount = 3,
                PickupDestination = "Brno",
                FinalDestination = "Hradec Králové",
                DateCreated = 123456789,
                Provide = null,
                Location = Locations[1]
            }
        };
    }


    public void CreateDriver(Driver driver)
    {

        Location location = new Location
        {
            Id = 3,
            Uuid = Guid.Empty,
            Longitude = driver.Location.Longitude,
            Latitude = driver.Location.Longitude,
            DriverId = driver.Id
        };

        Drivers.Add(driver);
        Locations.Add(location);
    }

    public Driver[] GetAllDrivers()
    {
        return Drivers.ToArray();
    }

    public Driver? GetDriverByUuid(Guid uuid)
    {
        return Drivers.FirstOrDefault(d => d.Uuid == uuid);
    }

    public bool RemoveDriverByUuid(Guid uuid)
    {
        throw new NotImplementedException();
    }
    
}