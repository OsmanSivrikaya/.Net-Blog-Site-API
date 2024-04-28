using MyBlogSite.Entity.Abstract;

namespace MyBlogSite.Entity
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid TypeId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<BlogLike> BlogLikes { get; set; } = new List<BlogLike>();
        public ICollection<BlogComment> BlogComments { get; set; } = new List<BlogComment>();
    }
}
