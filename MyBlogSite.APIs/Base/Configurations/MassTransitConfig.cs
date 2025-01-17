using MassTransit;
using MyBlogSite.Core.Dtos.Settings;

namespace Base.Configurations;

public static class MassTransitConfig
{
    public static void AddRabbitMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        var rabbitMqSettings = configuration.GetSection("RabbitMQ").Get<RabbitMqSettingDto>();
        services.AddMassTransit(x =>
        {
            // Default Port : 5672
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqSettings?.Url);
            });
        
        });
    }
}