using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Settings;
using MyBlogSite.Dtos.Token;

namespace MyBlogSite.Business.Services.Services
{
    //TODO: DÜZENLE
    public class TokenService(IOptions<TokenSettings> _tokenSettings) : ITokenService
    {
        public Task<GenerateTokenResponseDto> GenerateToken(GenerateTokenRequestDto request)
        {
            var tokenSettings = _tokenSettings.Value;
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));

            var claims = new List<Claim>
            {
                new Claim("userName", request.Username)
            };

            var dateTimeNow = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: tokenSettings.ValidIssuer,
                audience: tokenSettings.ValidAudience,
                claims: claims,
                notBefore: dateTimeNow,
                expires: dateTimeNow.Add(TimeSpan.FromMinutes(500)),
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Task.FromResult(new GenerateTokenResponseDto
            {
                Token = token,
                TokenExpireDate = dateTimeNow.Add(TimeSpan.FromMinutes(500))
            });
        }
    }
}