using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity;

public class Tag : BaseEntity
{
    [Column("content", TypeName = "nvarchar(400)")]
    public required string TagName { get; set; }
    
    [Column("slag", TypeName = "nvarchar(4000)")]
    public required string Slug { get; set; }
}