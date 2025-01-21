using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Dal.Repository.Repository;

public class UserRepository(ContextDb context) : Repository<User>(context), IUserRepository;