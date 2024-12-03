using LinkUp.Interfaces;
using LinkUp.Models;
using LinkUp.Data;
using Microsoft.EntityFrameworkCore;

namespace LinkUp.Services;

public class PostService : IPostService
{
    private readonly ApplicationDbContext _context;

    public PostService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Post> CreatePostAsync(Post post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> GetPostByIdAsync(Guid id)
    {
        return await _context.Posts.FindAsync(id);
    }

    public async Task<IEnumerable<Post>> GetUserPostsAsync(string userId)
    {
        return await _context.Posts
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }
    

    public async Task<Post> UpdatePostAsync(Post post)
    {
        post.UpdatedAt = DateTime.UtcNow;
        _context.Posts.Update(post);
        await _context.SaveChangesAsync();
        return post;
    }

public async Task<IEnumerable<Post>> GetVisiblePostsAsync()
{
    return await _context.Posts
        .Join(_context.Users, 
            post => post.UserId, 
            user => user.Id, 
            (post, user) => new { Post = post, User = user })
        .Where(x => x.User.IsPrivate == false)
        .Select(x => x.Post)
        .OrderByDescending(p => p.CreatedAt)
        .ToListAsync();
}

    public async Task DeletePostAsync(Guid id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post != null)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}