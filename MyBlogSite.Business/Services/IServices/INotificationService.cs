using MyBlogSite.Core.Dtos.ProducerDtos;

namespace MyBlogSite.Business.Services.IServices;

public interface INotificationService
{
    Task SendNotificationQueueAsync(NotificationMessageDto message);
}