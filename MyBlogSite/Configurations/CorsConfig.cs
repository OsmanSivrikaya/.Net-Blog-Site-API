namespace MyBlogSite.Configurations
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

            // CORS politikasını ekle
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins($"{url}:{port}")
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
        public static IApplicationBuilder AddCorsPolicy(this IApplicationBuilder app)
        {
            // CORS politikasını kullan
            app.UseCors("AllowSpecificOrigins");
            return app;
        }
    }
}
