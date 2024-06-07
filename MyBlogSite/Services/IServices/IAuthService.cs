using MyBlogSite.Dtos.Auth;

namespace MyBlogSite.Services.IServices
{
    public interface IAuthService
    {
        public Task<UserLoginResponseDto> LoginUserAsycn(UserLoginRequestDto request);
    }
}