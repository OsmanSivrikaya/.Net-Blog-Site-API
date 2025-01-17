using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;
using MyBlogSite.Data;

namespace MyBlogSite.Dal.Repository.Repository
{
    public class BlogLikeRepository : Repository<BlogLike>, IBlogLikeRepository
    {
        public BlogLikeRepository(ContextDb context) : base(context)
        {
        }
    }
}