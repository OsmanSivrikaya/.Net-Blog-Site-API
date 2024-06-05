using MyBlogSite.Context;
using MyBlogSite.Entity;
using MyBlogSite.Repository.IRepository;

namespace MyBlogSite.Repository.Repository
{
    public class BlogLikeRepository : Repository<BlogLike>, IBlogLikeRepository
    {
        public BlogLikeRepository(ContextDb context) : base(context)
        {
        }
    }
}