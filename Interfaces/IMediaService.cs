using Microsoft.AspNetCore.Http;

namespace LinkUp.Interfaces;

public interface IMediaService
{
    Task<string> UploadMediaAsync(IFormFile file);
    Task DeleteMediaAsync(string mediaUrl);
}