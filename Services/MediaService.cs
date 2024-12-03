using Azure.Storage.Blobs;
using LinkUp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace LinkUp.Services;

public class MediaService : IMediaService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly string _containerName;

    public MediaService(IConfiguration configuration)
    {
        _blobServiceClient = new BlobServiceClient(configuration["AzureBlob"]);
        _containerName = "media";
    }

    public async Task<string> UploadMediaAsync(IFormFile file)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        await containerClient.CreateIfNotExistsAsync();

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var blobClient = containerClient.GetBlobClient(fileName);

        await using var stream = file.OpenReadStream();
        await blobClient.UploadAsync(stream, true);

        return blobClient.Uri.ToString();
    }

    public async Task DeleteMediaAsync(string mediaUrl)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        var uri = new Uri(mediaUrl);
        var fileName = Path.GetFileName(uri.LocalPath);
        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.DeleteIfExistsAsync();
    }
}