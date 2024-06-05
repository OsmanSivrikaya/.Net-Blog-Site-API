using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Entity.Abstract;

namespace MyBlogSite.Entity
{
    public class BlogComment : BaseEntity
    {
        [Column("replied_comment_id")]
        public Guid? RepliedCommentId { get; set; }
        [Required]
        [Column("blog_id")]
        public Guid BlogId { get; set; }
        [Required]
        [Column("email", TypeName = "nvarchar(255)")]
        public required string EMail { get; set; }
        [Required]
        [Column("full_name", TypeName = "nvarchar(255)")]
        public required string FullName { get; set; }
        [Required]
        [Column("text", TypeName = "nvarchar(4000)")]
        public required string Text { get; set; }
        [Required]
        [Column("is_it_approved")]
        public bool IsItApproved { get; set; }
    }
}
