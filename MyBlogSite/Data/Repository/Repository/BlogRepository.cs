using MyBlogSite.Data.Repository.IRepository;
using MyBlogSite.Entity;

namespace MyBlogSite.Data.Repository.Repository
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(ContextDb context) : base(context)
        {
            
        }
    }
}