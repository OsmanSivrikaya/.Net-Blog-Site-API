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

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(rabbitMqSettings.Url));

                cfg.ReceiveEndpoint(rabbitMqSettings.MailQueueKey, e =>
                {
                    e.ConfigureConsumer<MailConsumer>(context);
                });
            });
        });

        return services;
    }
}
