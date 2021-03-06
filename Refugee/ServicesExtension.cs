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

    public static string GetHerokuConnectionString()
    {
        string? connectionUrl = Environment.GetEnvironmentVariable("DATASE_URL");

        if (connectionUrl is not null)
        {
            var databaseUri = new Uri(connectionUrl);
            string db = databaseUri.LocalPath.TrimStart('/');
            string[] userInfo = databaseUri.UserInfo.Split(':',StringSplitOptions.RemoveEmptyEntries);
            return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port={databaseUri.Port};Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
        }

        return "";
    }
}

