using MyBlogSite.Entity.Abstract;

namespace MyBlogSite.Entity
{
    public class BlogLike : BaseEntity
    {
        public string Email { get; set; }
        public Guid BlogId { get; set; }
    }
}
