
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Context;

namespace MyBlogSite.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["SQL_CONNECTION"];
            Console.WriteLine($"Sql Bilgisi: {connectionString}");
            services.AddDbContext<ContextDb>(options => options.UseSqlServer(connectionString));
        }
    }
}