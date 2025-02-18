using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.ProducerDtos;
using MyBlogSite.Core.Producers.Interface;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services;

public class NotificationService(
    INotificationRepository notificationRepository,
    INotificationProducer notificationProducer) : INotificationService
{
    public async Task SendNotificationQueueAsync(NotificationMessageDto message)
    {
        var notifications = message.UserIds.Select(userId => new Notification
        {
            UserId = userId,
            Type = message.Type,
            PostSlag = message.PostSlug,
            Message = message.Message,
            IsRead = false,
            IsDeleted = false
        }).ToList();
        
        await notificationRepository.CreateRangeAsync(notifications);
        
        await notificationProducer.SendNotificationQueueAsync(message);
    }
}