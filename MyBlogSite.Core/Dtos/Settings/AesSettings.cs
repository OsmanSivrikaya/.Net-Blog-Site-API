namespace MyBlogSite.Core.Dtos.Settings;

public class AesSettings
{
    public string Key { get; set; } = string.Empty;
    public string Iv { get; set; } = string.Empty;
}