using Serilog;

namespace Base.Configurations
{
    /// <summary>
    /// CORS yapılandırmalarını sağlayan sınıf.
    /// </summary>
    public static class CorsConfig
    {
        /// <summary>
        /// IServiceCollection'a CORS politikasını ekler.
        /// </summary>
        /// <param name="services">CORS politikasının ekleneceği IServiceCollection.</param>
        /// <param name="configuration">Konfigürasyon ayarlarını içeren IConfiguration.</param>
        /// <returns>CORS politikası eklenmiş IServiceCollection.</returns>
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["BASE_URL"];
            var port = configuration["PORT"];
            var baseUrl = url is not null && port is not null ? $"{url}:{port}" : "http://localhost:5288";
            Log.Information($"Cors Url: {baseUrl}");
            
            // Sadece köken kısmını almak için URI sınıfını kullan
            var uri = new Uri(baseUrl);
            var origin = $"{uri.Scheme}://{uri.Host}";

            // CORS politikasını ekle
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.SetIsOriginAllowed(_ => true)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            return services;
        }

        /// <summary>
        /// IApplicationBuilder'a CORS politikasını ekler.
        /// </summary>
        /// <param name="app">CORS politikasının ekleneceği IApplicationBuilder.</param>
        /// <returns>CORS politikası eklenmiş IApplicationBuilder.</returns>
        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
        {
            // CORS politikasını kullan
            app.UseCors("CorsPolicy");
            return app;
        }
    }
}
