using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Entity.Abstract;

namespace MyBlogSite.Entity
{
    public class Blog : BaseEntity
    {
        [Required]
        [Column("title", TypeName = "nvarchar(255)")]
        public required string Title { get; set; }
        [Required]
        [Column("text", TypeName = "nvarchar(4000)")]
        public required string Text { get; set; }
        [Required]
        [Column("type_id")]
        public Guid TypeId { get; set; }
        [Required]
        [Column("user_id")]
        [ForeignKey("user_id")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<BlogLike> BlogLikes { get; set; } = new List<BlogLike>();
        public ICollection<BlogComment> BlogComments { get; set; } = new List<BlogComment>();
    }
}
