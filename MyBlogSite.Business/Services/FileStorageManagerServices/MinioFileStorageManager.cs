using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;
using MyBlogSite.Business.Services.FileStorageManagerServices.Interface;
using MyBlogSite.Core.Dtos.Settings;
using MyBlogSite.Core.Enums;

namespace MyBlogSite.Business.Services.FileStorageManagerServices;

public class MinioFileStorageManager(MinioClient _minioClient) : IFileStorageManager
{
    public async Task<string> UploadFileAsync(IFormFile file, string folderName, string fileName)
    {
        var contentType = FileHelper.GetContentType(file);
        await using var stream = file.OpenReadStream();
        // PutObjectArgs ile yükleme işlemi yapılandırması
        var putObjectArgs = new PutObjectArgs()
            .WithObject(fileName)               // Yüklenen dosyanın adı
            .WithStreamData(stream)           // Dosya verisi
            .WithObjectSize(stream.Length)    // Dosyanın boyutu
            .WithContentType(contentType);        // Dosya türü (MIME type)

        // Dosyayı MinIO'ya yükleyin
        await _minioClient.PutObjectAsync(putObjectArgs);

        // Dosya başarıyla yüklendikten sonra, URL döndürülür
        //var fileUrl = $"https://your-minio-endpoint/{_bucketName}/{fileName}";
        return "";
    }

    public async Task<Stream> DownloadFileAsync(string fileName)
    {
        var memoryStream = new MemoryStream();
        // await _minioClient.GetObjectAsync(_bucketName, fileName, stream => stream.CopyTo(memoryStream));
        // memoryStream.Seek(0, SeekOrigin.Begin);
        return memoryStream;
    }

    public async Task<bool> DeleteFileAsync(string fileName)
    {
        // await _minioClient.RemoveObjectAsync(_bucketName, fileName);
        return true;
    }

    public async Task<bool> FileExistsAsync(string fileName)
    {
        try
        {
            // await _minioClient.StatObjectAsync(_bucketName, fileName);
            return true;
        }
        catch
        {
            return false;
        }
    }
}