using Refugee.Models.Entities;

namespace Refugee.Services;

public interface IDriverService
{
    public void CreateDriver(Driver driver);

    public Driver[] GetAllDrivers();

    public Driver? GetDriverByUuid(Guid uuid);

    public bool RemoveDriverByUuid(Guid uuid);

}