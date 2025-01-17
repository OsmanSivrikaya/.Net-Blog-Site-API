namespace MyBlogSite.Core.Dtos.User
{
    public class UserCreateDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? IsActive { get; set; }
    }
}