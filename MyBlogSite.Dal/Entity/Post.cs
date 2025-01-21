using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity;

public class Post : BaseEntity
{
    [Column("blog_id")]
    public required Guid BlogId { get; set; }

    // Her post bir bloga bağlı olmalı
    public Blog Blog { get; set; }

    [Column("title", TypeName = "nvarchar(255)")]
    public required string Title { get; set; }

    [Column("content", TypeName = "nvarchar(4000)")]
    public required string Content { get; set; }

    [Column("slag", TypeName = "nvarchar(4000)")]
    public required string Slug { get; set; }

    [ForeignKey("type_id")]
    [Column("type_id")]
    public required Guid TypeId { get; set; }

    // Post tipini tutuyor
    public PostType? Type { get; set; }

    [Column("user_id")]
    public required Guid UserId { get; set; }

    // Post'un sahibi olan kullanıcı
    public User User { get; set; }

    // Post ile ilişkilendirilen Tag'ler
    public ICollection<PostTag>? PostTags { get; set; }

    // Post'a gelen beğeniler
    public ICollection<PostLike>? BlogLikes { get; set; }

    // Post'a yapılan yorumlar
    public ICollection<PostComment>? BlogComments { get; set; }
}

