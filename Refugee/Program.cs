using Microsoft.EntityFrameworkCore;
using Refugee;
using Refugee.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = String.Empty;

if (builder.Environment.EnvironmentName == "Development")
{
    connectionString = builder.Configuration.GetConnectionString("all4ua");
}
else
{
    connectionString = ServicesExtension.GetHerokuConnectionString();
}


builder.Services.AddDbContext<ApplicationDbContext>(
    o => o.UseNpgsql(connectionString)
);

var serviceProvider = builder.Services.BuildServiceProvider();
try
{
    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}


var app = builder.Build();
app.MapGet("/", () => "Hello World!");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();