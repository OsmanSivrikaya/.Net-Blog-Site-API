namespace MyBlogSite.Core.Dtos.Settings;

public class RabbitMqSettingDto
{
    public string Url { get; set; } = string.Empty;
    public string MailQueueKey { get; set; } = string.Empty;
}