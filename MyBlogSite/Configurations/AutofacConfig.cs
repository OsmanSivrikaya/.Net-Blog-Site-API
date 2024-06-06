using Autofac;
using Autofac.Extensions.DependencyInjection;
using MyBlogSite.DependencyResolvers.Autofac;

namespace MyBlogSite.Configurations
{
    /// <summary>
    /// Autofac bağımlılık enjeksiyonu yapılandırmasını gerçekleştiren sınıf.
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        /// IHostBuilder üzerine Autofac yapılandırmasını ekler.
        /// </summary>
        /// <param name="host">Autofac yapılandırmasının ekleneceği IHostBuilder.</param>
        /// <returns>Autofac yapılandırması eklenmiş IHostBuilder.</returns>
        public static IHostBuilder AddAutofac(this IHostBuilder host)
        {
            // AutofacServiceProviderFactory kullanarak hizmet sağlayıcı fabrikasını ayarla
            // ve ContainerBuilder konfigürasyonunu yapılandır
            host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>((container) =>
                {
                    // AutofacBusinessModule'u kullanarak modülü kaydet
                    container.RegisterModule(new AutofacBusinessModule());
                });
            
            return host;
        }
    }
}
