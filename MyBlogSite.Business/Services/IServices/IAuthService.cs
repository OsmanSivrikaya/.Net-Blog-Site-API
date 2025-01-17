using MyBlogSite.Core.Dtos.Auth;

namespace MyBlogSite.Business.Services.IServices
{
    public interface IAuthService
    {
        public Task<UserLoginResponseDto> LoginUserAsycn(UserLoginRequestDto request);
    }
}