using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Core.Enums;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity;

public class Notification : BaseEntity
{
    /// <summary>
    /// Bildirim türü (Örn: Yeni Post, Yorum, Beğeni vb.).
    /// NotificationTypeEnum içinde tanımlanan türlerden biri olmalıdır.
    /// </summary>
    public NotificationTypeEnum Type { get; set; }
    
    /// <summary>
    /// Bildirimin ilgili olduğu post'un slug değeri.
    /// (Slug, post başlığından üretilmiş URL dostu bir metindir.)
    /// Örn: "ilk-blog-yazim"
    /// </summary>
    [Column("post_slag", TypeName = "nvarchar(4000)")]
    public string? PostSlag { get; set; }

    /// <summary>
    /// Kullanıcılara iletilecek bildirim mesajı.
    /// Örn: "Yeni bir yorum aldı" veya "Takip ettiğiniz kişi yeni bir post paylaştı"
    /// </summary>
    [Column("message", TypeName = "nvarchar(4000)")]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Bildirimin gönderileceği kullanıcıların ID'leri.
    /// Kullanıcılar sistemde GUID (Globally Unique Identifier) olarak tutulmaktadır.
    /// </summary>
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
    
    [Column("is_read")]
    public bool IsRead { get; set; }
}