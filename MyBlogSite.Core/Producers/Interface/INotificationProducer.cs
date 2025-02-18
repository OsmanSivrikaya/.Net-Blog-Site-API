using MyBlogSite.Core.Dtos.ProducerDtos;

namespace MyBlogSite.Core.Producers.Interface;

public interface INotificationProducer
{
    Task SendNotificationQueueAsync(NotificationMessageDto messageDto);
}