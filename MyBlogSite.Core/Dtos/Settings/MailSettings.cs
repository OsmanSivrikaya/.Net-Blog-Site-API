namespace MyBlogSite.Core.Dtos.Settings;

public class MailSettings
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public bool IsSsl { get; set; }
    public string Mail { get; set; }= string.Empty;
    public string AppPass { get; set; }= string.Empty;
}