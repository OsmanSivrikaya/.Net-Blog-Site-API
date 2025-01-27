namespace MyBlogSite.Core.Dtos.Auth
{
    public class UserLoginRequestDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}