using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Settings;
using MyBlogSite.Core.Dtos.Token;
using MyBlogSite.Dtos.Token;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MyBlogSite.Business.Services.Services
{
    //TODO: DÜZENLE
    public class TokenService(IOptions<TokenSettings> tokenSettings, IOptions<AesSettings> aesSettings) : ITokenService
    {
        private readonly TokenSettings _tokenSettings = tokenSettings.Value;
        private readonly AesSettings _aesSettings = aesSettings.Value;
        public Task<GenerateTokenResponseDto> GenerateToken(GenerateTokenRequestDto request)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));

            var claims = new List<Claim>
            {
                new Claim("userName", request.Username),
                new Claim( "userId", request.UserId.ToString()),
                new Claim("role", request.Role.ToString())
            };

            var dateTimeNow = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: _tokenSettings.ValidIssuer,
                audience: _tokenSettings.ValidAudience,
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
        
        public string Encrypt<T>(T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            // T tipini JSON formatına dönüştür
            var jsonData = JsonSerializer.Serialize(data);
            var dataBytes = Encoding.UTF8.GetBytes(jsonData);

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(_aesSettings.Key); // Anahtar
            aesAlg.IV = Encoding.UTF8.GetBytes(_aesSettings.Iv);  // IV

            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(dataBytes, 0, dataBytes.Length);
            }

            // Şifrelenmiş byte dizisini base64 string'e dönüştür
            return Convert.ToBase64String(ms.ToArray());
        }

        public T? Decrypt<T>(string encryptedData)
        {
            if (string.IsNullOrEmpty(encryptedData)) throw new ArgumentNullException(nameof(encryptedData));

            var cipherBytes = Convert.FromBase64String(encryptedData);

            using var aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(_aesSettings.Key); // Anahtar
            aesAlg.IV = Encoding.UTF8.GetBytes(_aesSettings.Iv);  // IV

            using var ms = new MemoryStream(cipherBytes);
            using var cs = new CryptoStream(ms, aesAlg.CreateDecryptor(), CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            var decryptedJson = sr.ReadToEnd();
            // JSON verisini T tipine deserialize et
            return JsonSerializer.Deserialize<T>(decryptedJson);
        }
    }
}