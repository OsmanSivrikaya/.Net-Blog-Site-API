using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Entity.Abstract;

namespace MyBlogSite.Entity
{
    public class BlogProperty : BaseEntity
    {
        [Required]
        [Column("number_of_views")]
        public int NumberOfViews { get; set; }
        [Required]
        [Column("blog_id")]
        [ForeignKey("blog_id")]
        public Guid BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
