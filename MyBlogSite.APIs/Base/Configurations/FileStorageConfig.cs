using Amazon.Runtime;
using Amazon.S3;
using Minio;
using MyBlogSite.Business.Services.FileStorageManagerServices;
using MyBlogSite.Business.Services.FileStorageManagerServices.Interface;
using MyBlogSite.Core.Dtos.Settings;

namespace Base.Configurations;

public static class FileStorageConfig
{
    public static IServiceCollection AddFileStoreageSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        var fileStorageConfig = configuration.GetSection("FILE_STORAGE").Get<FileStorageSettings>();
        services.AddSingleton(fileStorageConfig); 
        
        // ActiveProvider'a göre uygun yapılandırma ile MinIO client oluşturuluyor
        if (fileStorageConfig?.Type == FileStorageType.Minio)
        {
            var minioClient = new MinioClient()
                .WithEndpoint(fileStorageConfig?.MinioSettings?.Endpoint)
                .WithCredentials(fileStorageConfig?.MinioSettings?.AccessKey,
                    fileStorageConfig?.MinioSettings?.SecretKey)
                .Build();

            services.AddSingleton<IMinioClient>(minioClient);
            services.AddScoped<IFileStorageManager, MinioFileStorageManager>();
        }
        else if (fileStorageConfig?.Type == FileStorageType.Wasabi)
        {
            // var awsCredentials = new BasicAWSCredentials(fileStorageConfig?.WasabiSettings?.AccessKey,
            //     fileStorageConfig?.WasabiSettings?.SecretKey);
            // var s3Client1 = new AmazonS3Client(awsCredentials, Amazon.RegionEndpoint.EUCentral1);

            var s3Client = new AmazonS3Client(
                fileStorageConfig?.WasabiSettings?.AccessKey,
                fileStorageConfig?.WasabiSettings?.SecretKey,
                new AmazonS3Config
                {
                    ServiceURL = fileStorageConfig?.WasabiSettings?.Endpoint,
                });

            services.AddSingleton<IAmazonS3>(s3Client);
            services.AddScoped<IFileStorageManager, WasabiFileStorageManager>();
        }

        return services;
    }
}