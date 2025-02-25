using Base.Api;
using Base.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Admin.User;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Dtos.User;

namespace Admin.Controllers;

/// <summary>
/// Kullanıcı işlemlerini yöneten API controller sınıfı.
/// </summary>
[ApiVersion("1")]
[Route("admin/user")]
public class UserController(IUserService userService) : BaseController
{
    /// <summary>
    /// Tüm kullanıcıları getiren endpoint.
    /// </summary>
    [Authorize]
    [HttpGet]
    public async Task<PaginationResult<UserViewDto>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10) => await userService.GetAllUsersPagination(pageNumber, pageSize);
    
    /// <summary>
    /// User detay bilgisi için kullanılır.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [Authorize]
    [HttpGet("{userId}")]
    public async Task<Result> GetUsersForAdminPageAsync([FromRoute] Guid userId) => await userService.GetUsersForAdminPageAsync(userId);

    /// <summary>
    /// Kullanıcının aktifliğini kaldırır
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [Transaction]
    [HttpDelete("{userId}")]
    public async Task<Result> SetUserActivationStatusAsync([FromRoute] UserActivationStatusDto request) => await userService.SetUserActivationStatusAsync(request.IsActive, request.UserId);
    
    /// <summary>
    /// Blog'a bağlı olan kullanıcının blog'la bağlantısını kaldırır.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [Authorize]
    [Transaction]
    [HttpDelete("remove-user-blog-role/{userId}")]
    public async Task<Result> RemoveUserFromBlogRoleAsync([FromRoute] Guid userId) => await userService.RemoveUserFromBlogRoleAsync(userId);
    
    /// <summary>
    /// User güncelleme işleminde kullanılır.
    /// </summary>
    /// <param name="userUpdateDto"></param>
    /// <returns></returns>
    [Authorize]
    [Transaction]
    [HttpPut("{Id}")]
    public Result Update(UserUpdateDto userUpdateDto) => userService.Update(userUpdateDto);

    /// <summary>
    /// Kullanıcı erişimi engellemek için kullanılır.
    /// Eğer kullanıcının blog'u var ise ve bu blog'da tek kişi ise blog'uda banlanır.
    /// Eğer blog yönetiminde birden fazla kullanıcı var ise banlanan blog kurucusunun yetkileri random bir kullanıcıya atanır ve blog erişimi engellenmez.
    /// </summary>
    /// <param name="userBanStatusDto"></param>
    /// <returns></returns>
    [Authorize]
    [Transaction]
    [HttpPost("ban-user/{UserId}")]
    public async Task<Result> BanUserAsync(UserBanStatusDto userBanStatusDto) =>
        await userService.SetUserBanStatusAsync(userBanStatusDto.UserId, userBanStatusDto.IsBanned);
}