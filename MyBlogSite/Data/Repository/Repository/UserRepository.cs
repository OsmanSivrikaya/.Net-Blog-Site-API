using MyBlogSite.Data.Repository.IRepository;
using MyBlogSite.Entity;

namespace MyBlogSite.Data.Repository.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ContextDb context) : base(context)
        {
        }
    }
}