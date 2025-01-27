using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Base.Configurations
{
    /// <summary>
    /// API sürümlendirme yapılandırmasını eklemek için kullanılan genişletme yöntemleri sağlar.
    /// </summary>
    public static class ApiVersioningConfig
    {
        /// <summary>
        /// IServiceCollection'a API sürümlendirme yapılandırmasını ekler.
        /// </summary>
        /// <param name="services">Servis koleksiyonu.</param>
        /// <returns>API sürümlendirme yapılandırması eklenmiş IServiceCollection.</returns>
        public static IServiceCollection AddCustomApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(x =>
            {
                //Belirli bir sürüm belirtilmediğinde varsayılan sürümün kullanılmasını sağlar.
                x.AssumeDefaultVersionWhenUnspecified = true;
                //Varsayılan API sürümünü belirler. Bu örnekte 1.0 olarak ayarlanmıştır.
                x.DefaultApiVersion = ApiVersion.Default;
                // API'nin desteklediği sürümlerin raporlanmasını sağlar.
                x.ReportApiVersions = true;
                // API sürümünün nasıl okunacağını belirler. Bu örnekte, sorgu dizesi, HTTP başlığı ve URL segmenti üzerinden sürüm bilgisinin okunması birleştirilmiştir.
                x.ApiVersionReader = ApiVersionReader.Combine(
                    // new QueryStringApiVersionReader("api-version"),
                    // new HeaderApiVersionReader("api-version"),
                    new UrlSegmentApiVersionReader()
                    );
            }).AddVersionedApiExplorer(x =>
            {
                // API sürümünün nasıl gruplandırılacağını belirleriz; burada ‘v’V formatı, sürümlerin v1, v2 gibi gösterilmesini sağlar.
                x.GroupNameFormat = "'v'V";
                // API belgelerinde ve Swagger UI’da URL’lerde sürüm bilgisinin dinamik olarak değiştirilmesi sağlanır.
                x.SubstituteApiVersionInUrl = true;
            });
            return services;
        }
    }
}
