using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace MyBlogSite.WebFramework.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Repository'leri otomatik olarak kaydetme
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Repository")) // Tüm repository sınıflarını seç
                   .AsImplementedInterfaces() //Seçilen sınıfların uyguladığı arayüzlerle ilişkilendir
                   // AddScoped yapıyoruzki her db işleminde yeni bir repository oluştursun ve db isteklerinde çakışmayı engellesin
                   .InstancePerLifetimeScope(); // Servisleri HTTP isteği ömrüyle eşleştirerek kaydet

            // Servislerin otomatik olarak kaydedilmesi
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.Name.EndsWith("Service")) // Tüm servis sınıflarını seç
            .AsImplementedInterfaces() // Seçilen sınıfların uyguladığı arayüzlerle ilişkilendir
                                       // AddScoped yapıyoruz ki her HTTP isteğinde yeni bir servis örneği oluşturulsun
                                       // ve HTTP isteklerinde servislerin paylaşılması engellensin
            .InstancePerLifetimeScope(); // Servisleri HTTP isteği ömrüyle eşleştirerek kaydet
        }
    }
}