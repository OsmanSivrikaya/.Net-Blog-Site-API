using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity;

public class PostTag : BaseEntity
{
    [ForeignKey("post_id")]
    [Column("post_id")]
    public required Guid PostId { get; set; }
    
    public Post? Post { get; set; }
    
    [ForeignKey("tag_id")]
    [Column("tag_id")]
    public required Guid TagId { get; set; }
    
    public Tag? Tag { get; set; }
}