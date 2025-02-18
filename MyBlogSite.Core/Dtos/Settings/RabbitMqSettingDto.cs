namespace MyBlogSite.Core.Dtos.Settings;

public class RabbitMqSettingDto
{
    public string Url { get; set; } = string.Empty;
    
    /// <summary>
    /// Email rabbitmq kuyruk ismi
    /// </summary>
    public string MailQueueKey { get; set; } = string.Empty;
    
    /// <summary>
    /// SignalR rabbitmq kuyruk ismi
    /// </summary>
    public string SignalrQueueKey { get; set; } = string.Empty;
}