using MyBlogSite.Data.Repository.IRepository;
using MyBlogSite.Entity;

namespace MyBlogSite.Data.Repository.Repository
{
    public class BlogLikeRepository : Repository<BlogLike>, IBlogLikeRepository
    {
        public BlogLikeRepository(ContextDb context) : base(context)
        {
        }
    }
}