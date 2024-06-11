using System.Linq.Expressions;
using MyBlogSite.Data.Repository.IRepository;
using MyBlogSite.Entity;
using MyBlogSite.Services.IServices;

namespace MyBlogSite.Services.Services
{
    public class UserService(IUserRepository _userRepository) : IUserService
    {
         public async Task<User?> GetFirstAsync(Expression<Func<User, bool>> method){
            return await _userRepository.GetFirstAsync(method);
         }
    }
}