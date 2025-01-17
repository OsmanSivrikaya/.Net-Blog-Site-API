namespace MyBlogSite.Core.Dtos.User
{
    public class UserViewDto
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}