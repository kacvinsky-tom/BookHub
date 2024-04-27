namespace Core.Clients;

public interface IImageBlobClient
{
    Task UploadImageAsync(string blobName, Stream data);
    Uri GetImage(string blobName);
}