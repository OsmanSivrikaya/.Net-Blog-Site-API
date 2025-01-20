namespace MyBlogSite.Core.Dtos.Settings;

public class FileStorageSettings
{
    public FileStorageType Type { get; set; }
    public MinioSettings? MinioSettings { get; set; } 
}

public class MinioSettings
{
    public string Endpoint { get; set; } = string.Empty;
    public string AccessKey { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
    public string BucketName { get; set; } = string.Empty;
}

public enum FileStorageType
{
    Minio,
}