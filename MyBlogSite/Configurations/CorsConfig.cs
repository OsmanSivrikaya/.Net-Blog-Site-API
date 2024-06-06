namespace MyBlogSite.Configurations
{
    public static class CorsConfig
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["BASE_URL"];
            var port = configuration["PORT"];
            // CORS politikasını ekleyin
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

        public static IApplicationBuilder AddCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors("AllowSpecificOrigins");
            return app;
        }
    }
}