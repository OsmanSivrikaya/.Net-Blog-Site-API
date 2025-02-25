using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity;

public class Blog : BaseEntity
{
    [Column("blog_name", TypeName = "nvarchar(150)")]
    public required string BlogName { get; set; }

    [Column("slag", TypeName = "nvarchar(4000)")]
    public required string Slug { get; set; }

    [Column("blog_description", TypeName = "nvarchar(4000)")]
    public string? Description { get; set; }
    public List<User> Users { get; set; }
    
    [Column("is_active")]
    public bool IsActive { get; set; }
    
    [ForeignKey(nameof(User))]
    [Column("founder_user_id")]
    public Guid? FounderUserId { get; set; }
    
    [Column("is_banned")] 
    public required bool IsBanned { get; set; }
}
