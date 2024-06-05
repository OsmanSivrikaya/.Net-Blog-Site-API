using MyBlogSite.Entity;
using MyBlogSite.Repository.IRepository;
using MyBlogSite.Context;

namespace MyBlogSite.Repository.Repository
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(ContextDb context) : base(context)
        {
            
        }
    }
}