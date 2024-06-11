using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Dtos.Auth;
using MyBlogSite.Dtos.Response;
using MyBlogSite.Services.IServices;
using MyBlogSite.WebFramework.Api;

namespace MyBlogSite.Controllers.v1
{
    [ApiVersion("1")]
    public class AuthController(IAuthService _authService) : BaseController
    {
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUserAsync(UserLoginRequestDto request){
            var result = await _authService.LoginUserAsycn(request);
            if(result is null)
                return ResponseDto.NotFound("Kullanıcı bulunamadı!");
            return ResponseDto.Ok(null, result);
        }
    }
}