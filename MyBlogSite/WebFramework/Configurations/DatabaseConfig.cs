using Microsoft.EntityFrameworkCore;
using MyBlogSite.Data;
using Serilog;

namespace MyBlogSite.WebFramework.Configurations
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

            // Serilog ile bağlantı bilgisini logla
            Log.Information($"Sql Bilgisi: {connectionString}");

            // DbContext'i ekleyin
            services.AddDbContext<ContextDb>(options => options.UseSqlServer(connectionString));
        }
    }
}
