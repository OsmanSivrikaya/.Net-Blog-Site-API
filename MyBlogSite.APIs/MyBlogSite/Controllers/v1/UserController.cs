using Base.Api;
using Base.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Dtos.User;

namespace MyBlogSite.Controllers.v1;

/// <summary>
/// Kullanıcı işlemlerini yöneten API controller sınıfı.
/// </summary>
[ApiVersion("1")]
[Route("user")]
public class UserController(IUserService userService) : BaseController
{
    /// <summary>
    /// Tüm kullanıcıları getiren endpoint.
    /// </summary>
    [Authorize]
    [HttpGet]
    public async Task<PaginationResult<UserViewDto>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10) => await userService.GetAllUsersPagination(pageNumber, pageSize);

    /// <summary>
    /// Yeni kullanıcı oluşturan endpoint.
    /// </summary>
    /// <param name="userCreateDto">Oluşturulacak kullanıcı veri transfer nesnesi.</param>
    [HttpPost]
    [ValidateModel]
    [Transaction]
    public async Task<Result> UserCreate(UserCreateDto userCreateDto)
    {
        var user = await userService.CreateAsync(userCreateDto);
        return Result.Ok(user);
    }
}