using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity
{
    public class BlogProperty : BaseEntity
    {
        [Required]
        [Column("number_of_views")]
        public int NumberOfViews { get; set; }
        [Required]
        [Column("blog_id")]
        [ForeignKey("Blog")]
        public Guid BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
