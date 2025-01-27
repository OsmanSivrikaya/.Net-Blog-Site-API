using MyBlogSite.Core.Dtos.Auth;
using MyBlogSite.Core.Dtos.Response;

namespace MyBlogSite.Business.Services.IServices
{
    public interface IAuthService
    {
        Task<UserLoginResponseDto> LoginUserAsycn(UserLoginRequestDto request);
        Task<Result> ResetPassword(UserResetPasswordRequestDto passwordRequest);
        Task<Result> ApproveResetPassword(UserResetPasswordApproveRequestDto request);
    }
}