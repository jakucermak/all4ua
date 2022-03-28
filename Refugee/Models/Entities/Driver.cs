using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Refugee.Models.Entities;

public class Driver
{
    [Key]
    public int Id { get; set; }
    [Column("uuid")]
    [JsonPropertyName("uuid")]
    [Required]
    public Guid Uuid { get; set; }
    [Column("first_name")]
    [JsonPropertyName("first_name")]
    [Required]
    public string FirstName { get; set; } = default!; 
    [Column("last_name")]
    [JsonPropertyName("last_name")]
    [Required]
    public string LastName { get; set; } = default!;
    [Column("email")]
    [JsonPropertyName("email")]
    [Required]
    public string Email { get; set; } = default!;
    [Column("phone_number")]
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; } = default!;
    [Column("adults_amount")]
    [JsonPropertyName("adults_amount")]
    [Required]
    public int AdultsAmount { get; set; }
    [Column("kids_amount")]
    [JsonPropertyName("kids_amount")]
    [Required]
    public int KidsAmount { get; set; }
    [Column("pickup_destination")]
    [JsonPropertyName("pickup_destination")]
    [Required]
    public string PickupDestination { get; set; } = default!;
    [Column("final_destination")]
    [JsonPropertyName("final_destination")]
    [Required]
    public string FinalDestination { get; set; } = default!;
    [Column("date_Created")]
    [JsonPropertyName("date_created")]
    public double DateCreated { get; set; }
    [Column("provide")]
    [JsonPropertyName("provide")]
    public string Provide { get; set; } = default!;
    [Column("location_id")]
    [JsonPropertyName("gps_location")]
    public Location Location { get; set; } = default!;
}