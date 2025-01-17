using MyBlogSite.Core.Dtos.Settings;

namespace Base.Configurations;

public static class SettingsConfig
{
    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var smsSettings = configuration.GetSection("AppSettings");
        services.Configure<TokenSettings>(smsSettings);
        
        services.AddSingleton<IConfiguration>(configuration);
        
        return services;
    }
}