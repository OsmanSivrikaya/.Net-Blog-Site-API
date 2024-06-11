using System.Linq.Expressions;
using MyBlogSite.Dtos.User;
using MyBlogSite.Entity;

namespace MyBlogSite.Services.IServices
{
    public interface IUserService
    {
        Task<List<UserViewDto>> GetAllUsers();
        Task<User?> GetFirstAsync(Expression<Func<User, bool>> method);
        Task<UserViewDto> CreateAsync(UserCreateDto userCreateDto);
    }
}