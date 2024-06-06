using MyBlogSite.AutoMapper;

namespace MyBlogSite.Configurations
{
    /// <summary>
    /// Auto mapper ayarlamalarının yapıldığı method
    /// </summary>
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services){
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}