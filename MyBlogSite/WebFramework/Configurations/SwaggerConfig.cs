using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MyBlogSite.WebFramework.Configurations
{
    /// <summary>
    /// Swagger konfigürasyonunu yapılandırmak için yardımcı sınıf.
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Servislere Swagger desteğini ekler.
        /// </summary>
        /// <param name="services">IServiceCollection nesnesi</param>
        /// <returns>IServiceCollection nesnesi</returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            // ConfigureSwaggerOptions sınıfının SwaggerGenOptions yapılandırma seçeneklerini ayarlamak için kullanıldığını belirten bir kayıt işlemidir.
            // Bu adımın amacı, Swagger yapılandırmasını merkezi bir yerden yönetmek ve API versiyonlaması gibi gelişmiş ayarları kolayca uygulamaktır.
            // ConfigureSwaggerOptions sınıfının geçici bir örneğini oluşturur.
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // SwaggerGen'i servislere ekler ve konfigürasyonlarını belirler.
            services.AddSwaggerGen(options =>
            {
                // Swagger dokümantasyonuna Bearer token kimlik doğrulama tanımlar.
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Lütfen 'Bearer {token}' formatında token girin",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Bearer token kimlik doğrulama gereksinimini Swagger dokümantasyonuna ekler.
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });

                // XML yorum dosyasını yükler. Bu dosya, API belgeleri için yorumları içerir.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

            return services;
        }

        /// <summary>
        /// Web uygulamasına Swagger ve Swagger UI desteğini ekler.
        /// </summary>
        /// <param name="app">WebApplication nesnesi</param>
        /// <returns>WebApplication nesnesi</returns>
        public static WebApplication UseSwaggerConfig(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                // IApiVersionDescriptionProvider servisini alır
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                // Her bir API versiyonu için Swagger UI'de bir uç nokta ekler
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
            return app;
        }
    }

    /// <summary>
    /// Swagger seçeneklerini yapılandırmak için kullanılan sınıf.
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        /// <summary>
        /// API versiyonları hakkında bilgi sağlayan sağlayıcı.
        /// </summary>
        private readonly IApiVersionDescriptionProvider _provider;

        /// <summary>
        /// ConfigureSwaggerOptions sınıfının kurucusu.
        /// </summary>
        /// <param name="provider">API versiyonları hakkında bilgi sağlayan sağlayıcı.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

        /// <summary>
        /// SwaggerGenOptions yapılandırmasını gerçekleştirir.
        /// </summary>
        /// <param name="options">SwaggerGenOptions örneği.</param>
        public void Configure(SwaggerGenOptions options)
        {
            // Her bir API versiyonu için ayrı bir Swagger dokümanı oluşturur.
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                // Swagger dokümanı için gerekli bilgileri ayarlar.
                options.SwaggerDoc(description.GroupName, new OpenApiInfo
                {
                    Title = $"My API {description.ApiVersion}", // API başlığı (versiyon bilgisi ile birlikte).
                    Version = description.ApiVersion.ToString(), // API versiyonu.
                    Description = "Bu, API versiyonu açıklamasıdır." // API dokümanı açıklaması.
                });
            }
        }
    }
}
