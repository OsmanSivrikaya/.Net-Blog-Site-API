using MyBlogSite.WebFramework.Middlewares;

namespace MyBlogSite.WebFramework.Configurations
{
    /// <summary>
    /// Uygulamanın istek işlem hattına özel middleware'leri eklemek için genişletme metotlarını içerir.
    /// </summary>
    public static class MiddlewareConfig
    {
        /// <summary>
        /// Özel middleware'leri uygulamanın istek işlem hattına ekler.
        /// </summary>
        /// <param name="app">Middleware'in ekleneceği <see cref="IApplicationBuilder"/>.</param>
        /// <returns>Middleware'in eklendiği <see cref="IApplicationBuilder"/>.</returns>
        public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder app)
        {
            // Özel hata yönetim middleware'ini istek işlem hattına ekler.
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }
    }
}
