using Microsoft.EntityFrameworkCore;

namespace MyBlogSite.Context
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;"));
        }
    }
}
