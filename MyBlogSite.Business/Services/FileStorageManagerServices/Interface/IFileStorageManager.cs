using Microsoft.AspNetCore.Http;
using MyBlogSite.Core.Dtos.FileStoreManagerDtos;

namespace MyBlogSite.Business.Services.FileStorageManagerServices.Interface;

public interface IFileStorageManager
{
    Task<UploadResponseDto> UploadFileAsync(IFormFile file, string folderName, string fileName);
    Task<Stream> DownloadFileAsync(string fileName);
    Task<bool> DeleteFileAsync(string fileName);
    Task<bool> FileExistsAsync(string fileName);
}