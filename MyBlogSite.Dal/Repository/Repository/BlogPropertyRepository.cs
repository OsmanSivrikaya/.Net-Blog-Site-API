using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;
using MyBlogSite.Data;

namespace MyBlogSite.Dal.Repository.Repository
{
    public class BlogPropertyRepository : Repository<BlogProperty>, IBlogPropertRepository
    {
        public BlogPropertyRepository(ContextDb context) : base(context)
        {
        }
    }
}