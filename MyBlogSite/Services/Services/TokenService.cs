using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MyBlogSite.Dtos.Token;
using MyBlogSite.Services.IServices;

namespace MyBlogSite.Services.Services
{
    public class TokenService(IConfiguration _configuration) : ITokenService
    {
        public Task<GenerateTokenResponseDto> GenerateToken(GenerateTokenRequestDto request)
        {
            var secretKey = _configuration["AppSettings:Secret"];
            var issuer = _configuration["AppSettings:ValidIssuer"];
            var audience = _configuration["AppSettings:ValidAudience"];

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new List<Claim>
            {
                new Claim("userName", request.Username)
            };

            var dateTimeNow = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
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