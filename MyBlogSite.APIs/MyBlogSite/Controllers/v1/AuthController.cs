using Base.Api;
using Base.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Auth;
using MyBlogSite.Core.Dtos.Response;

namespace MyBlogSite.Controllers.v1;

[ApiVersion("1")]
[Route("auth")]
public class AuthController(IAuthService authService) : BaseController
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<Result> LoginUserAsync(UserLoginRequestDto request) =>
        Result.Ok(await authService.LoginUserAsycn(request));

    [HttpPost("reset-password-generate-token")]
    [AllowAnonymous]
    [ValidateModel]
    public async Task<Result> PasswordResetGenerateToken(UserResetPasswordRequestDto request) =>
        await authService.ResetPassword(request);

    [HttpPost("reset-password")]
    [AllowAnonymous]
    [ValidateModel]
    [Transaction]
    public async Task<Result> PasswordReset(UserResetPasswordApproveRequestDto request) =>
        await authService.ApproveResetPassword(request);
}