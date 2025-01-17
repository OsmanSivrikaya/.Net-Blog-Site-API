using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity
{
    public class User : BaseEntity
    {
        [Column("username", TypeName = "nvarchar(100)")]
        public required string Username { get; set; }
        [Column("password", TypeName = "nvarchar(300)")]
        public required string Password { get; set; }
        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}
