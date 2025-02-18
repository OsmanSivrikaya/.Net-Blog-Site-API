using MassTransit;
using Microsoft.Extensions.Options;
using MyBlogSite.Core.Dtos.ProducerDtos;
using MyBlogSite.Core.Dtos.Settings;
using MyBlogSite.Core.Producers.Interface;

namespace MyBlogSite.Core.Producers;

public class NotificationProducer(
    ISendEndpointProvider sendEndpointProvider,
    IOptions<RabbitMqSettingDto> rabbitMqSettings) : INotificationProducer
{
    private readonly RabbitMqSettingDto _rabbitMqSettings = rabbitMqSettings.Value;
    public async Task SendNotificationQueueAsync(NotificationMessageDto messageDto)
    {
        try
        {
            var sendPoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{_rabbitMqSettings.SignalrQueueKey}"));
            await sendPoint.Send(messageDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}