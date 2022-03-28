using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Refugee.Models.Entities;

public class Location
{
    [Key]
    public int Id { get; set; }
    [Column("uuid")]
    [JsonIgnore]
    public Guid Uuid { get; set; }
    [Column("longitude")]
    public double Longitude { get; set; }
    [Column("latitude")]
    public double Latitude { get; set; }
    [ForeignKey("driver_id")]
    [Column("driver_id")]
    [JsonIgnore]
    public int DriverId { get; set; }
    [JsonIgnore]
    public  Driver Driver { get; }
}