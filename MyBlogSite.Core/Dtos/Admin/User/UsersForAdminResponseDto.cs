using MyBlogSite.Core.Enums;

namespace MyBlogSite.Core.Dtos.Admin.User;

public class UsersForAdminResponseDto
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required bool IsActive { get; set; }
    public RoleEnum Role { get; set; }
    public bool IsExecutive { get; set; }
    public required Guid? BlogId { get; set; }
}