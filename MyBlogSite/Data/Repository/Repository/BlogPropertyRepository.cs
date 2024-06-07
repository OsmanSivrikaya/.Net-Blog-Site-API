using MyBlogSite.Data.Repository.IRepository;
using MyBlogSite.Entity;

namespace MyBlogSite.Data.Repository.Repository
{
    public class BlogPropertyRepository : Repository<BlogProperty>, IBlogPropertRepository
    {
        public BlogPropertyRepository(ContextDb context) : base(context)
        {
        }
    }
}