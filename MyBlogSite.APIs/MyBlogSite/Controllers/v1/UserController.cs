using Base.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.WebFramework.Api;

namespace MyBlogSite.Controllers.v1
{
    /// <summary>
    /// Kullanıcı işlemlerini yöneten API controller sınıfı.
    /// </summary>
    [ApiVersion("1")]
    public class UserController(IUserService _userService) : BaseController
    {
        /// <summary>
        /// Tüm kullanıcıları getiren endpoint.
        /// </summary>
        [Authorize]
        [HttpGet]
        public async Task<Result> GetAll() => Result.Ok(await _userService.GetAllUsers());
        
        /// <summary>
        /// Yeni kullanıcı oluşturan endpoint.
        /// </summary>
        /// <param name="userCreateDto">Oluşturulacak kullanıcı veri transfer nesnesi.</param>
        [HttpPost]
        [ValidateModel] 
        [Transaction]
        public async Task<Result> UserCreate(UserCreateDto userCreateDto)
        {
            var user = await _userService.CreateAsync(userCreateDto);
            return Result.Ok(user);
        }
    }
}