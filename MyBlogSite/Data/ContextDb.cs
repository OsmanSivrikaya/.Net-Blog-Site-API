using Microsoft.EntityFrameworkCore;
using MyBlogSite.Entity;

namespace MyBlogSite.Data
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        { }

        public DbSet<Blog> blogs { get; set; } 
        public DbSet<BlogComment> blog_comments { get; set; } 
        public DbSet<BlogLike> blog_likes { get; set; } 
        public DbSet<BlogProperty> blog_properties { get; set; } 
        public DbSet<BlogType> blog_types { get; set; } 
        public DbSet<Ticket> tickets { get; set; } 
        public DbSet<User> users { get; set; } 
    }
}

