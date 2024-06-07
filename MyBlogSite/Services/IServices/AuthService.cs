using MyBlogSite.Dtos.Auth;
using MyBlogSite.Dtos.Token;

namespace MyBlogSite.Services.IServices
{
    public class AuthService(ITokenService _tokenService) : IAuthService
    {
        public async Task<UserLoginResponseDto?> LoginUserAsycn(UserLoginRequestDto request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }

            // TODO: User olmadığı için deneme amaçlı kod içerisine eklenmiştir
            if (request.Username == "osman" && request.Password == "123")
            {
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequestDto { Username = request.Username });
                return new UserLoginResponseDto{
                    AuthenticateResult = true,
                    AuthToken = generatedTokenInformation.Token,
                    AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate
                };
            }
            return null;
        }
    }
}