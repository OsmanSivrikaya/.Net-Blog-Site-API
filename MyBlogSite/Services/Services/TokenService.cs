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
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]!));

            var dateTimeNow = DateTime.UtcNow;

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: _configuration["AppSettings:ValidIssuer"],
                    audience: _configuration["AppSettings:ValidAudience"],
                    claims: new List<Claim> {
                        new Claim("userName", request.Username)
                    },
                    notBefore: dateTimeNow,
                    expires: dateTimeNow.Add(TimeSpan.FromMinutes(500)),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );

            return Task.FromResult(new GenerateTokenResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                TokenExpireDate = dateTimeNow.Add(TimeSpan.FromMinutes(500))
            });
        }
    }
}