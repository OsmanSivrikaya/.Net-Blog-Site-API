using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;
using MyBlogSite.Data;

namespace MyBlogSite.Dal.Repository.Repository
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(ContextDb context) : base(context)
        {
            
        }
    }
}