using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos;
using MyBlogSite.Core.Dtos.Auth;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Producers.Interface;
using MyBlogSite.WebFramework.Api;

namespace MyBlogSite.Controllers.v1
{
    [ApiVersion("1")]
    public class AuthController(IAuthService _authService, IEmailProducer _emailProducer) : BaseController
    {
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<Result> LoginUserAsync(UserLoginRequestDto request){
            var result = await _authService.LoginUserAsycn(request);
            if(result is null)
                return Result.NotFound("Kullanıcı bulunamadı!");
            return Result.Ok(null, result);
        }
        [HttpPost("mail-deneme")]
        [AllowAnonymous]
        public async Task<Result> MailDeneme(){
            await _emailProducer.SendEmailQueueAsync(new EmailMessageDto
            {
                Subject = "Deneme",
                ToEmails = new List<string>{"osmansivrikaya@outlook.com"},
                Body = "Deneme için atılmıştır."
            });
            return Result.Ok("Başarılı");
        }
    }
}