using Microsoft.EntityFrameworkCore;
using MyBlogSite.Entity;

namespace MyBlogSite.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        { }

        public DbSet<Blog> blogs { get; set; } 
    }
}
