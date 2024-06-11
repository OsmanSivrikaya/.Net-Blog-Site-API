using MyBlogSite.Common.Utilities;
using MyBlogSite.Dtos.Auth;
using MyBlogSite.Dtos.Token;

namespace MyBlogSite.Services.IServices
{
    public class AuthService(ITokenService _tokenService, IUserService _userService) : IAuthService
    {
        public async Task<UserLoginResponseDto?> LoginUserAsycn(UserLoginRequestDto request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }

            var hashPassword = HashHelper.ComputeSHA256Hash(request.Password);
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