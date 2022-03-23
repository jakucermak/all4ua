using Refugee.Database;
using Refugee.Services;

namespace Refugee;

public static class ServicesExtension
{
    public static void RegisterServices(this IServiceCollection collection)
    {
        collection.AddTransient<DriverService>();
        collection.AddTransient<LocationService>();
//        collection.AddTransient<ApplicationDbContext>();
    }
}