using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;
using MyBlogSite.Data;

namespace MyBlogSite.Dal.Repository.Repository
{
    public class BlogCommentRepository : Repository<BlogComment>, IBlogCommentRepository
    {
        public BlogCommentRepository(ContextDb context) : base(context)
        {
        }
    }
}