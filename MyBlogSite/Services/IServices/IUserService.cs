using System.Linq.Expressions;
using MyBlogSite.Entity;

namespace MyBlogSite.Services.IServices
{
    public interface IUserService
    {
        Task<User?> GetFirstAsync(Expression<Func<User, bool>> method);
    }
}