using MyBlogSite.Business.CustomMappping;

namespace Base.Configurations
{
    /// <summary>
    /// AutoMapper yapılandırmalarını sağlayan sınıf.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// IServiceCollection'a AutoMapper yapılandırmasını ekler.
        /// </summary>
        /// <param name="services">AutoMapper yapılandırmasının ekleneceği IServiceCollection.</param>
        /// <returns>AutoMapper yapılandırması eklenmiş IServiceCollection.</returns>
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            // AutoMapper yapılandırmasını IServiceCollection'a ekle
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
