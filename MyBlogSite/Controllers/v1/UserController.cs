using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Dtos.Response;
using MyBlogSite.Dtos.User;
using MyBlogSite.Services.IServices;
using MyBlogSite.WebFramework.Api;
using MyBlogSite.WebFramework.Attributes;

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
        [HttpGet]
        public IActionResult GetAll() => ResponseDto.Ok(_userService.GetAllUsers().Result);
        
        /// <summary>
        /// Yeni kullanıcı oluşturan endpoint.
        /// </summary>
        /// <param name="userCreateDto">Oluşturulacak kullanıcı veri transfer nesnesi.</param>
        [HttpPost]
        [ValidateModel] 
        [Transaction]
        public IActionResult UserCreate(UserCreateDto userCreateDto)
        {
            var user = _userService.CreateAsync(userCreateDto).Result;
            return ResponseDto.Ok(user);
        }
    }
}