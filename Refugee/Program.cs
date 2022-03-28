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

string connectionString;
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



var app = builder.Build();
app.MapGet("/", () => connectionString);

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