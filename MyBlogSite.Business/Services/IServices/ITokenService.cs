using MyBlogSite.Core.Dtos.Token;
using MyBlogSite.Dtos.Token;

namespace MyBlogSite.Business.Services.IServices
{
    public interface ITokenService
    {
        Task<GenerateTokenResponseDto> GenerateToken(GenerateTokenRequestDto request);
        string Encrypt<T>(T data);
        T? Decrypt<T>(string encryptedData);
    }
}