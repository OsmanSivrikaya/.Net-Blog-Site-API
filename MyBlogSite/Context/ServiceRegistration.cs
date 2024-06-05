using Microsoft.EntityFrameworkCore;

namespace MyBlogSite.Context
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            string connectionString = "Server=analizgaraj.com\\MSSQLSERVER2019;Database=analizga_blog;User Id=analizga_pollify;Password=tq0m5E7~1;TrustServerCertificate=True;";
            services.AddDbContext<ContextDb>(options => options.UseSqlServer(connectionString));
        }
    }
}
