using MyBlogSite.Entity.Abstract;

namespace MyBlogSite.Entity
{
    public class BlogComment : BaseEntity
    {
        public Guid? RepliedCommentId { get; set; }
        public Guid BlogId { get; set; }
        public string EMail { get; set; }
        public string FullName { get; set; }
        public string Text { get; set; }
        public bool IsItApproved { get; set; }
    }
}
