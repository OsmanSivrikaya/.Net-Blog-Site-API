using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity
{
    public class PostType : BaseEntity
    {
        [Required]
        [Column("type_name", TypeName = "nvarchar(255)")]
        public required string TypeName { get; set; }
        
        [Column("slag", TypeName = "nvarchar(4000)")]
        public required string Slug { get; set; }
        
        [Column("is_active")]
        public required bool IsActive { get; set; }
        
        [Column("is_deleted")]
        public required bool IsDeleted { get; set; }
    }
}
