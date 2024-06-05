using MyBlogSite.Context;
using MyBlogSite.Entity;
using MyBlogSite.Repository.IRepository;

namespace MyBlogSite.Repository.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ContextDb context) : base(context)
        {
        }
    }
}