namespace MyBlogSite.Core.Dtos.Auth
{
    public class UserLoginRequestDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}