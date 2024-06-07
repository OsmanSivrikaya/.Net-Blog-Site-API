using MyBlogSite.Data.Repository.IRepository;
using MyBlogSite.Entity;

namespace MyBlogSite.Data.Repository.Repository
{
    public class BlogTypeRepository : Repository<BlogType>, IBlogTypeRepository
    {
        public BlogTypeRepository(ContextDb context) : base(context)
        {
        }
    }
}