using System.Linq.Expressions;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.Dal.Entity;

namespace MyBlogSite.Business.Services.IServices
{
    public interface IUserService
    {
        Task<PaginationResult<UserViewDto>> GetAllUsersPagination(int pageNumber, int pageSize);
        Task<User?> GetFirstAsync(Expression<Func<User, bool>> method);
        Task<UserViewDto> RegisterUserAsync(UserRegisterDto userRegisterDto);
        UserUpdateDto Update(UserUpdateDto userUpdateDto);
        Task<bool> BeExistingUsername(string? username, CancellationToken cancellationToken);
        Task<bool> BeExistingEmail(string? username, CancellationToken cancellationToken);
    }
}