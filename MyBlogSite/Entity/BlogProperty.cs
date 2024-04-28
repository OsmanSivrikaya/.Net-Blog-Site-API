using MyBlogSite.Entity.Abstract;

namespace MyBlogSite.Entity
{
    public class BlogProperty : BaseEntity
    {
        public int NumberOfViews { get; set; }
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
