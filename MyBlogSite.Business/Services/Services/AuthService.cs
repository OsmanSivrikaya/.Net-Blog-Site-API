using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Auth;
using MyBlogSite.Core.Utilities;
using MyBlogSite.Dtos.Token;

namespace MyBlogSite.Business.Services.Services
{
    public class AuthService(ITokenService _tokenService, IUserService _userService) : IAuthService
    {
        public async Task<UserLoginResponseDto?> LoginUserAsycn(UserLoginRequestDto request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }

            var hashPassword = HashHelper.ComputeSha256Hash(request.Password);
            var user = await _userService.GetFirstAsync(x => x.Username == request.Username && x.Password == hashPassword);

            if (user is not null)
            {
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequestDto { Username = request.Username });
                return new UserLoginResponseDto
                {
                    AuthenticateResult = true,
                    AuthToken = generatedTokenInformation.Token,
                    AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate
                };
            }
            return null;
        }
    }
}