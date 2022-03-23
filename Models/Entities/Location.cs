using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Refugee.Models.Entities;

public class Location
{
    [Key]
    public int Id { get; set; }
    [Column("uuid")]
    public Guid Uuid { get; set; }
    [Column("longitude")]
    public double Longitude { get; set; }
    [Column("latitude")]
    public double Latitude { get; set; }
    [ForeignKey("driver_id")]
    [Column("driver_id")]
    public int DriverId { get; set; }
    public Driver Driver { get; }
}