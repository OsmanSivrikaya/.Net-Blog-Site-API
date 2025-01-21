using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity
{
    public class PostLike : BaseEntity
    {
        [Column("email", TypeName = "nvarchar(255)")]
        public required string Email { get; set; }
        
        [ForeignKey("post_id")]
        [Column("post_id")]
        public required Guid PostId { get; set; }
        
        public Post? Post { get; set; }
    }
}
