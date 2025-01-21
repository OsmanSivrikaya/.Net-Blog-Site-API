using Base.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Auth;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Producers.Interface;

namespace MyBlogSite.Controllers.v1
{
    [ApiVersion("1")]
    [Route("auth")]
    public class AuthController(IAuthService _authService, IEmailProducer _emailProducer) : BaseController
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<Result> LoginUserAsync(UserLoginRequestDto request){
            var result = await _authService.LoginUserAsycn(request);
            if(result is null)
                return Result.NotFound("Kullanıcı bulunamadı!");
            return Result.Ok(null, result);
        }
        
    }
}