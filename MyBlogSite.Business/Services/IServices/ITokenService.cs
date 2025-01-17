using MyBlogSite.Dtos.Token;

namespace MyBlogSite.Business.Services.IServices
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponseDto> GenerateToken(GenerateTokenRequestDto request);
    }
}