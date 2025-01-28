using Microsoft.EntityFrameworkCore;
using MyBlogSite.Dal.Entity;

namespace MyBlogSite.Dal;

public class ContextDb(DbContextOptions<ContextDb> options) : DbContext(options)
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<PostComment> BlogComments { get; set; }
    public DbSet<PostLike> BlogLikes { get; set; }
    public DbSet<PostType> BlogTypes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().ToTable("blogs");
        modelBuilder.Entity<Post>().ToTable("post");
        modelBuilder.Entity<PostComment>().ToTable("post_comments");
        modelBuilder.Entity<PostLike>().ToTable("post_likes");
        modelBuilder.Entity<PostType>().ToTable("post_types");
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<PostTag>().ToTable("post_tags");
        modelBuilder.Entity<Tag>().ToTable("tags");
        
        base.OnModelCreating(modelBuilder);

        // Blog ve User ilişkisini belirt
        modelBuilder.Entity<User>()
            .HasOne(u => u.Blog)   // Bir User bir Blog'a ait
            .WithMany(b => b.Users)  // Bir Blog birden fazla User alabilir
            .HasForeignKey(u => u.BlogId)  // User'ın BlogId'si ile ilişkiyi kur
            .OnDelete(DeleteBehavior.Restrict);  // Silme sırasında kısıtlama yap
    }
}