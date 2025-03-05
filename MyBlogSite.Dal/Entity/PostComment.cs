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
        
        /// <summary>
        /// Yorumun hangi yoruma cevap olduğu (ana yorumsa NULL)
        /// </summary>
        [Column("parent_comment_id")]
        public Guid? ParentCommentId { get; set; }
        
        /// <summary>
        /// Yorum yapan kişinin e-posta adresi
        /// </summary>
        [ForeignKey(nameof(User))]
        [Column("user_id")]
        public required Guid UserId { get; set; }
        
        public required User User { get; set; }
        
        /// <summary>
        /// Yorum içeriği
        /// </summary>
        [Column("content", TypeName = "varchar(4000)")]
        public required string Content { get; set; }
        
        [Column("is_deleted")]
        public required bool IsDeleted { get; set; }
    }
}
