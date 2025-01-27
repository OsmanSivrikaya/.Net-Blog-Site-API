namespace MyBlogSite.Core.Dtos.User
{
    public class UserRegisterDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public RegisterBlogDto? Blog { get; set; } = null;
    }

    public class RegisterBlogDto
    {
        public string? BlogName { get; set; }
        public string? Description { get; set; }
    }
}