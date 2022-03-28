using System.ComponentModel.DataAnnotations;

namespace Refugee.Models.Entities;

public class User
{
    [Required]
    public string Username { get; set; }
    public string Password { get; set; }
}