using MyBlogSite.Context;
using MyBlogSite.Entity;
using MyBlogSite.Repository.IRepository;

namespace MyBlogSite.Repository.Repository
{
    public class BlogPropertyRepository : Repository<BlogProperty>, IBlogPropertRepository
    {
        public BlogPropertyRepository(ContextDb context) : base(context)
        {
        }
    }
}