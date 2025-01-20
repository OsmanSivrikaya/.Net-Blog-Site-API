using MyBlogSite.Core.Dtos.Settings;

namespace Base.Configurations;

public static class SettingsConfig
{
    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var smsSettings = configuration.GetSection("AppSettings");
        services.Configure<TokenSettings>(smsSettings);
        
        var rabbitMqSettings = configuration.GetSection("RabbitMQ");
        services.Configure<RabbitMqSettingDto>(rabbitMqSettings);
        
        var mailSettings = configuration.GetSection("MAIL_CONNECTION");
        services.Configure<MailSettings>(mailSettings);
        
        services.AddSingleton<IConfiguration>(configuration);
        
        return services;
    }
}