using System.ComponentModel.DataAnnotations;

namespace LinkUp.Models.Auth;

public class RegisterRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    public bool IsPrivate { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }
}