using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Refugee.Models.Entities;

public class Driver
{
    [Key]
    public int Id { get; set; }
    [Column("uuid")]
    [Required]
    public Guid Uuid { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; } = default!; 
    [Column("last_name")]
    public string LastName { get; set; } = default!;
    [Column("email")]
    public string Email { get; set; } = default!;
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = default!;
    [Column("adults_amount")]
    public int AdultsAmount { get; set; }
    [Column("kids_amount")]
    public int KidsAmount { get; set; }
    [Column("pickup_destination")]
    public string PickupDestination { get; set; } = default!;
    [Column("final_destination")]
    public string FinalDestination { get; set; } = default!;
    [Column("date_Created")]
    public double DateCreated { get; set; }
    [Column("provide")]
    public string Provide { get; set; } = default!;
    [Column("location_id")]
    public Location Location { get; set; } = default!;
}