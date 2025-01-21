namespace MyBlogSite.Core.Dtos.User
{
    public class UserCreateDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? IsActive { get; set; }
        public CreateBlogDto Blog { get; set; } = new CreateBlogDto();
    }

    public class CreateBlogDto
    {
        public string? BlogName { get; set; }
        public string? Description { get; set; }
    }
}