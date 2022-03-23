using System.Text.Json.Serialization;

namespace Refugee.ViewModels;

public class DriverViewModel
{
    [JsonPropertyName("uuid")]
    public Guid Uuid { get; set; }
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = default!;
    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = default!;
    [JsonPropertyName("email")]
    public string Email { get; set; } = default!;
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; } = default!;
    [JsonPropertyName("adults_amount")]
    public int AdultsAmount { get; set; }
    [JsonPropertyName("kids_amount")]
    public int KidsAmount { get; set; }
    [JsonPropertyName("pickup_destination")]
    public string PickupDestination { get; set; } = default!;
    [JsonPropertyName("final_destination")]
    public string FinalDestination { get; set; } = default!;
    [JsonPropertyName("date_created")]
    public double DateCreated { get; set; }
    [JsonPropertyName("provide")]
    public string Provide { get; set; } = default!;
    [JsonPropertyName("gps_location")]
    public LocationViewModel Location { get; set; } = default!;
}