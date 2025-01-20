namespace MyBlogSite.Business.Services.FileStorageManagerServices.Interface;

public interface IFileStorageManager
{
    Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);
    Task<Stream> DownloadFileAsync(string fileName);
    Task<bool> DeleteFileAsync(string fileName);
    Task<bool> FileExistsAsync(string fileName);
}