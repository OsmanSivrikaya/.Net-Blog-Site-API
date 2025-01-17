using MassTransit;
using MyBlogSite.Core.Dtos.Settings;

namespace MailConsumer.Configurations;

public static class MasTransitConfig
{
    public static IServiceCollection AddMassTransitConsumers(this IServiceCollection services, RabbitMqSettingDto rabbitMqSettings)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<MailConsumer>();

            // Default Port : 5672
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqSettings.Url, host =>
                {
                });

                cfg.ReceiveEndpoint(rabbitMqSettings.MailQueueKey, e =>
                {
                    e.ConfigureConsumer<MailConsumer>(context);
                });
            });
        });
        
        return services;
    }
}