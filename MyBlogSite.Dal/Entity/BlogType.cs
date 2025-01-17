using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity
{
    public class BlogType : BaseEntity
    {
        [Required]
        [Column("type_name", TypeName = "nvarchar(255)")]
        public required string TypeName { get; set; }
    }
}
