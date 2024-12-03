using LinkUp.Models;

namespace LinkUp.Interfaces;
public interface IPostService
{
    Task<Post> CreatePostAsync(Post post);
    Task<Post?> GetPostByIdAsync(Guid id);
    Task<IEnumerable<Post>> GetUserPostsAsync(string userId);
    Task<Post> UpdatePostAsync(Post post);
    Task DeletePostAsync(Guid id);
    Task<IEnumerable<Post>> GetVisiblePostsAsync();
}
