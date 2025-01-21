using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity
{
    public class PostComment : BaseEntity
    {
        /// <summary>
        /// Yorumun bağlı olduğu yazı
        /// </summary>
        [ForeignKey("post_id")]
        [Column("post_id")]
        public required Guid PostId { get; set; }
        
        public Post? Post { get; set; }
        
        /// <summary>
        /// Yorumun hangi yoruma cevap olduğu (ana yorumsa NULL)
        /// </summary>
        [Column("parent_comment_id")]
        public Guid? ParentCommentId { get; set; }
        
        /// <summary>
        /// Yorum yapan kişinin e-posta adresi
        /// </summary>
        [Column("email", TypeName = "nvarchar(255)")]
        public required string Email { get; set; }
        
        /// <summary>
        /// Yorumu yapan kullanıcı üye değil ise ismi yer alır null ise üyedir
        /// </summary>
        [Column("full_name", TypeName = "nvarchar(255)")]
        public string? FullName { get; set; }
        
        /// <summary>
        /// Yorum içeriği
        /// </summary>
        [Column("content", TypeName = "nvarchar(4000)")]
        public required string Content { get; set; }
    }
}
