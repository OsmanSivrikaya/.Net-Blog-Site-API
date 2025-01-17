using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;
using MyBlogSite.Data;

namespace MyBlogSite.Dal.Repository.Repository
{
    public class BlogTypeRepository : Repository<BlogType>, IBlogTypeRepository
    {
        public BlogTypeRepository(ContextDb context) : base(context)
        {
        }
    }
}