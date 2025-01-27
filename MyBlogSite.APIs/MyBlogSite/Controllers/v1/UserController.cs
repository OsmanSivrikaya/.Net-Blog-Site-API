using Base.Api;
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
}