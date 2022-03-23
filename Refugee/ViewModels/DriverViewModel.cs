using System.Text.Json.Serialization;

namespace Refugee.ViewModels;

public class DriverViewModel
{
    [JsonPropertyName("uuid")]
    public Guid Uuid { get; set; }
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
    [JsonPropertyName("adults_amount")]
    public int AdultsAmount { get; set; }
    [JsonPropertyName("kids_amount")]
    public int KidsAmount { get; set; }
    [JsonPropertyName("pickup_destination")]
    public string PickupDestination { get; set; }
    [JsonPropertyName("final_destination")]
    public string FinalDestination { get; set; }
    [JsonPropertyName("date_created")]
    public double DateCreated { get; set; }
    [JsonPropertyName("provide")]
    public string Provide { get; set; }
    [JsonPropertyName("gps_location")]
    public LocationViewModel Location { get; set; }
}