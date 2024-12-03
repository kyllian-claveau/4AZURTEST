using Microsoft.AspNetCore.Identity;

namespace LinkUp.Models.Auth;
public class ApplicationUser : IdentityUser
{
    public bool IsPrivate { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}