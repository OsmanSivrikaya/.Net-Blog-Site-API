using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Base.Exceptions;
using Microsoft.AspNetCore.Http;
using MyBlogSite.Business.Services.FileStorageManagerServices.Interface;
using MyBlogSite.Core.Dtos.Settings;
using MyBlogSite.Core.Enums;

namespace MyBlogSite.Business.Services.FileStorageManagerServices
{
    public class WasabiFileStorageManager(IAmazonS3 s3Client, FileStorageSettings fileStorageSettings)
        : IFileStorageManager
    {
        private readonly TransferUtility _transferUtility = new TransferUtility(s3Client);

        public async Task<string> UploadFileAsync(IFormFile file, string folderName, string fileName)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Geçersiz dosya!");

            var bucketName = fileStorageSettings.WasabiSettings?.BucketName;

            try
            {
                var bucketExists = await CreateBucketAsync(bucketName);
                if (!bucketExists)
                    throw new NotFoundException(fileName);

                var uploadRequest = new PutObjectRequest()
                {
                    BucketName = bucketName,
                    Key = $"{folderName}/{GetUniqueFileName(fileName)}",
                    InputStream = file.OpenReadStream(),
                    ContentType = file.ContentType,
                    CannedACL = S3CannedACL.PublicRead
                };
                await s3Client.PutObjectAsync(uploadRequest);

                return
                    $"https://{s3Client.Config.ServiceURL}/{fileStorageSettings.WasabiSettings?.BucketName}/{fileName}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                throw;
            }
        }

        public async Task<Stream> DownloadFileAsync(string fileName)
        {
            var getRequest = new GetObjectRequest
            {
                BucketName = fileStorageSettings.WasabiSettings?.BucketName,
                Key = fileName
            };

            var response = await s3Client.GetObjectAsync(getRequest);
            var memoryStream = new MemoryStream();
            await response.ResponseStream.CopyToAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }

        public async Task<bool> DeleteFileAsync(string fileName)
        {
            var deleteRequest = new DeleteObjectRequest
            {
                BucketName = fileStorageSettings.WasabiSettings?.BucketName,
                Key = fileName
            };

            await s3Client.DeleteObjectAsync(deleteRequest);
            return true;
        }

        public async Task<bool> FileExistsAsync(string fileName)
        {
            try
            {
                var request = new GetObjectMetadataRequest
                {
                    BucketName = fileStorageSettings.WasabiSettings?.BucketName,
                    Key = fileName
                };

                await s3Client.GetObjectMetadataAsync(request);
                return true;
            }
            catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
        }

        #region Private Methods

        private string GetUniqueFileName(string fileName)
        {
            return string.Concat(Path.GetFileNameWithoutExtension(fileName), "_",
                Path.GetRandomFileName().Replace(".", ""), Path.GetExtension(fileName));
        }

        /// <summary>
        /// bucket file oluşturur
        /// </summary>
        /// <param name="bucketName"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        private async Task<bool> CreateBucketAsync(string? bucketName)
        {
            var bucketExists = await s3Client.DoesS3BucketExistAsync(bucketName);
            if (!bucketExists)
                await s3Client.PutBucketAsync(bucketName);
            return true;
        }

        /// <summary>
        /// Bucket listesini getirir
        /// </summary>
        /// <returns></returns>
        private async Task<ListBucketsResponse> GetAllBucketsAsync()
        {
            var bucketList = await s3Client.ListBucketsAsync();
            return bucketList;
        }

        /// <summary>
        /// var olan bucketı siler
        /// </summary>
        /// <param name="bucketName"></param>
        private async Task DeleteBucketAsync(string bucketName)
        {
            await s3Client.DeleteBucketAsync(bucketName);
        }

        #endregion
    }
}