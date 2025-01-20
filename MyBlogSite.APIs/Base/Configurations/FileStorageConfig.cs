using Minio;
using MyBlogSite.Business.Services.FileStorageManagerServices;
using MyBlogSite.Business.Services.FileStorageManagerServices.Interface;
using MyBlogSite.Core.Dtos.Settings;

namespace Base.Configurations;

public static class FileStorageConfig
{
    public static IServiceCollection AddFileStoreageSettings(this IServiceCollection services, IConfiguration configuration)
    {
        // appsettings.json'dan FileStorage yapılandırmasını alıyoruz
        var fileStorageConfig = configuration.GetSection("FILE_STORAGE").Get<FileStorageSettings>();

        // ActiveProvider'a göre uygun yapılandırma ile MinIO client oluşturuluyor
        if (fileStorageConfig?.Type == FileStorageType.Minio)
        {
            var minioClient = new MinioClient()
                .WithEndpoint(fileStorageConfig?.MinioSettings?.Endpoint)
                .WithCredentials(fileStorageConfig?.MinioSettings?.AccessKey, fileStorageConfig?.MinioSettings?.SecretKey)
                .Build();

            services.AddSingleton<IMinioClient>(minioClient);
            services.AddScoped<IFileStorageManager, MinioFileStorageManager>();
        }
        return services;    
    }
}