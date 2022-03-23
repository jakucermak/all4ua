using Microsoft.EntityFrameworkCore;
using Refugee.Models.Entities;

namespace Refugee.Database;

public class ApplicationDbContext : DbContext
{
    //Set Collections DbSet<Type>
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Location> Locations { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Set Relationship
        modelBuilder.Entity<Driver>()
            .HasOne(d => d.Location)
            .WithOne(l => l.Driver);
    }
}