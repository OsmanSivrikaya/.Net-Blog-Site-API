using Microsoft.EntityFrameworkCore;
using MyBlogSite.Dal;

namespace Base.Configurations
{
    /// <summary>
    /// Veritabanı yapılandırmalarını sağlayan sınıf.
    /// </summary>
    public static class DatabaseConfig
    {
        /// <summary>
        /// IServiceCollection'a veritabanı hizmetlerini ekler.
        /// </summary>
        /// <param name="services">Veritabanı hizmetlerinin ekleneceği IServiceCollection.</param>
        /// <param name="configuration">Konfigürasyon ayarlarını içeren IConfiguration.</param>
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Bağlantı dizesini al
            var connectionString = configuration["SQL_CONNECTION"];
            // DbContext'i ekleyin
            services.AddDbContext<ContextDb>(options => options.UseSqlServer(connectionString));
        }
    }
}
