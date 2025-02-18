using MassTransit;
using Microsoft.AspNetCore.SignalR;
using MyBlogSite.Core.Dtos.ProducerDtos;

namespace NotificationConsumer;

/// <summary>
/// RabbitMQ üzerinden gelen bildirim mesajlarını tüketen consumer.
/// Kullanıcılara SignalR Hub üzerinden bildirim gönderir.
/// </summary>
public class NotificationConsumer(IHubContext<NotificationHub> hubContext) : IConsumer<NotificationMessageDto>
{
    /// <summary>
    /// RabbitMQ'dan gelen bildirimi tüketir ve SignalR ile ilgili kullanıcılara yollar.
    /// </summary>
    /// <param name="context">MassTransit tüketici bağlamı.</param>
    public async Task Consume(ConsumeContext<NotificationMessageDto> context)
    {
        var message = context.Message;
        if (message.UserIds is { Count: > 0 })
        {
            // Kullanıcı ID'leri GUID olduğu için string'e çevirmeliyiz
            foreach (var userId in message.UserIds.Select(id => id.ToString()))
            {
                await hubContext.Clients.User(userId).SendAsync("ReceiveNotification", message);
            }
        }
        else
        {
            // Genel bildirim (Herkese gönderilecekse)
            await hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}