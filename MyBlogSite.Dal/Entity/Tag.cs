using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Core.Enums;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity;

public class Tag : BaseEntity
{
    [Column("content", TypeName = "varchar(400)")]
    public required string TagName { get; set; }
    
    [Column("tag_status")]
    public required TagStatus TagStatus { get; set; }
}