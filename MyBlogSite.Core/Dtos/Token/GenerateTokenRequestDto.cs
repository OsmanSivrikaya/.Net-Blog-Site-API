using MyBlogSite.Core.Enums;

namespace MyBlogSite.Core.Dtos.Token
{
    public class GenerateTokenRequestDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public RoleEnum Role { get; set; }
    }
}