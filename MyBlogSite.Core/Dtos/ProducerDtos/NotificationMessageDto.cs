using MyBlogSite.Core.Enums;

namespace MyBlogSite.Core.Dtos.ProducerDtos;

/// <summary>
/// Kullanıcılara gönderilecek bildirim mesajı DTO'su.
/// </summary>
public class NotificationMessageDto
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
    public string? PostSlug { get; set; }

    /// <summary>
    /// Kullanıcılara iletilecek bildirim mesajı.
    /// Örn: "Yeni bir yorum aldı" veya "Takip ettiğiniz kişi yeni bir post paylaştı"
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Bildirimin gönderileceği kullanıcıların ID'leri.
    /// Kullanıcılar sistemde GUID (Globally Unique Identifier) olarak tutulmaktadır.
    /// </summary>
    public List<Guid> UserIds { get; set; } = [];

    /// <summary>
    /// Bildirimin oluşturulma tarihi.
    /// Varsayılan olarak anlık zaman (UTC) atanmalıdır.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}