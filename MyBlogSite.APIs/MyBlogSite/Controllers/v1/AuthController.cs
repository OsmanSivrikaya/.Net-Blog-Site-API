using Base.Api;
using Base.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Auth;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Dtos.User;

namespace MyBlogSite.Controllers.v1;

[ApiVersion("1")]
[Route("auth")]
public class AuthController(IAuthService authService, IUserService userService) : BaseController
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<Result> LoginUserAsync(UserLoginRequestDto request) =>
        Result.Ok(await authService.LoginUserAsycn(request));

    /// <summary>
    /// Yeni kullanıcı oluşturan endpoint.
    /// </summary>
    /// <param name="userRegisterDto">Oluşturulacak kullanıcı veri transfer nesnesi.</param>
    [HttpPost("register")]
    [ValidateModel]
    [Transaction]
    public async Task<Result> UserRegister(UserRegisterDto userRegisterDto) =>
        Result.Ok(await userService.RegisterUserAsync(userRegisterDto));

    /// <summary>
    /// Şifre sıfırlama için token ile mail atar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("reset-password-generate-token")]
    [AllowAnonymous]
    [ValidateModel]
    public async Task<Result> PasswordResetGenerateToken(UserResetPasswordRequestDto request) =>
        await authService.ResetPassword(request);

    /// <summary>
    /// Şifre sıfırlamak için kullanılır.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("reset-password")]
    [AllowAnonymous]
    [ValidateModel]
    [Transaction]
    public async Task<Result> PasswordReset(UserResetPasswordApproveRequestDto request) =>
        await authService.ApproveResetPassword(request);
}