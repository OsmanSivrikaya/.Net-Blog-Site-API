using System.Linq.Expressions;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.Dal.Entity;

namespace MyBlogSite.Business.Services.IServices
{
    public interface IUserService
    {
        Task<List<UserViewDto>> GetAllUsers();
        Task<User?> GetFirstAsync(Expression<Func<User, bool>> method);
        Task<UserViewDto> CreateAsync(UserCreateDto userCreateDto);
    }
}