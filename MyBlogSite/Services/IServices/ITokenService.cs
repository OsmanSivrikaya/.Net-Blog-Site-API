using MyBlogSite.Dtos.Token;

namespace MyBlogSite.Services.IServices
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponseDto> GenerateToken(GenerateTokenRequestDto request);
    }
}