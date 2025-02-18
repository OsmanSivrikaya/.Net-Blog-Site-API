namespace MyBlogSite.Core.Dtos.FileStoreManagerDtos;

public class UploadResponseDto
{
    public string FileType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string FileUrl { get; set; } = string.Empty;
    public string FileDirectory { get; set; } = string.Empty;
}