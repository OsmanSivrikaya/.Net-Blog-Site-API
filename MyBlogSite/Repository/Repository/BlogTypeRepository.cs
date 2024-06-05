using MyBlogSite.Context;
using MyBlogSite.Entity;
using MyBlogSite.Repository.IRepository;

namespace MyBlogSite.Repository.Repository
{
    public class BlogTypeRepository : Repository<BlogType>, IBlogTypeRepository
    {
        public BlogTypeRepository(ContextDb context) : base(context)
        {
        }
    }
}