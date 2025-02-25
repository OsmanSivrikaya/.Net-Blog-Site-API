using System.Linq.Expressions;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.Dal.Entity;

namespace MyBlogSite.Business.Services.IServices
{
    public interface IUserService
    {
        Task<PaginationResult<UserViewDto>> GetAllUsersPagination(int pageNumber, int pageSize);
        Task<Result> GetUsersForAdminPageAsync(Guid userId);
        Task<Result> SetUserActivationStatusAsync(bool isActive, Guid userId);
        Task<Result> RemoveUserFromBlogRoleAsync(Guid userId);
        Task<Result> SetUserBanStatusAsync(Guid userId, bool isBan);
        Task<User?> GetFirstAsync(Expression<Func<User, bool>> method);
        Task<List<Guid>> GetAllUserByBlogIdAsync(Guid blogId);
        Task<UserViewDto> RegisterUserAsync(UserRegisterDto userRegisterDto);
        Result Update(UserUpdateDto userUpdateDto);
        Task<bool> BeExistingUsername(string? username, CancellationToken cancellationToken);
        Task<bool> BeExistingEmail(string? mail, CancellationToken cancellationToken = default, Guid? userId = null);
        Task<bool> BeExisting(Guid userId, CancellationToken cancellationToken);
    }
}