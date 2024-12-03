using LinkUp.Models.Auth;

namespace LinkUp.Models;

public class Post
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserId { get; set; }
    public string Content { get; set; }
    public List<string> MediaUrls { get; set; } = new();
    public ApplicationUser User { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}