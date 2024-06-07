using MyBlogSite.Data.Repository.IRepository;
using MyBlogSite.Entity;

namespace MyBlogSite.Data.Repository.Repository
{
    public class BlogCommentRepository : Repository<BlogComment>, IBlogCommentRepository
    {
        public BlogCommentRepository(ContextDb context) : base(context)
        {
        }
    }
}