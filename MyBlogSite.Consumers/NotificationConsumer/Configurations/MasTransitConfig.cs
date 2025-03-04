using MassTransit;
using MyBlogSite.Core.Dtos.Settings;

namespace NotificationConsumer.Configurations;

public static class MasTransitConfig
{
    public static IServiceCollection AddMassTransitConsumers(this IServiceCollection services, RabbitMqSettingDto rabbitMqSettings)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<NotificationConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(rabbitMqSettings.Url), h =>
                {
                    h.UseSsl(s =>
                    {
                        s.Protocol = System.Security.Authentication.SslProtocols.Tls12;
                    });
                });

                cfg.ReceiveEndpoint(rabbitMqSettings.SignalrQueueKey, e =>
                {
                    e.ConfigureConsumer<NotificationConsumer>(context);
                });
            });
        });
        
        return services;
    }
}