using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;


namespace Core.Clients;

public class ImageBlobClient : IImageBlobClient
{
    private readonly BlobContainerClient _client;
    public ImageBlobClient(BlobContainerClient client)
    {
        _client = client;
    }

    public async Task UploadImageAsync(string blobName, Stream data)
    {
        var blobClient = _client.GetBlobClient(blobName);
        await blobClient.UploadAsync(data, true);
    }
    public Uri GetImage(string blobName)
    {
        var blobClient = _client.GetBlobClient(blobName);
        BlobSasBuilder sasBuilder = new BlobSasBuilder()
        {
            BlobContainerName = blobClient.GetParentBlobContainerClient().Name,
            BlobName = blobClient.Name,
            Resource = "b"
        };
        var expire = sasBuilder.ExpiresOn;
        sasBuilder.ExpiresOn = DateTimeOffset.MaxValue;
        sasBuilder.SetPermissions(BlobContainerSasPermissions.Read);
        
        var sasUri = blobClient.GenerateSasUri(sasBuilder);

        return sasUri;
    }
}