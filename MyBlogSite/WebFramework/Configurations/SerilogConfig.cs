using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace MyBlogSite.WebFramework.Configurations
{
    /// <summary>
    /// Uygulamada Serilog'un yapılandırılması için genişletme yöntemleri.
    /// </summary>
    public static class SerilogConfig
    {
        /// <summary>
        /// IServiceCollection'a Serilog yapılandırmasını ekler.
        /// </summary>
        /// <param name="services">Serilog yapılandırmasının ekleneceği IServiceCollection.</param>
        /// <param name="configuration">Serilog yapılandırma ayarlarını içeren IConfiguration.</param>
        public static void AddSerilogConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // Yapılandırmadan SQL bağlantı dizesini al
            var connectionString = configuration["SQL_CONNECTION"];
            // Serilog'u yapılandır
            services.AddSerilog(options =>
            {
                // IConfiguration'dan Serilog yapılandırmasını oku
                options.ReadFrom.Configuration(configuration)
                // Log olaylarını MSSQL Server'a yaz
                .WriteTo.MSSqlServer(connectionString, new MSSqlServerSinkOptions
                {
                    TableName = "log_events", // Olayların saklanacağı tablonun adını belirle
                    AutoCreateSqlTable = true // Tablo otomatik olarak oluşturulsun mu?
                });
            });
        }
    }
}
