using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Core.Enums;

namespace MyBlogSite.Core.Dtos.User;

public class UserUpdateDto
{
    [FromRoute]
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public string? Password1 { get; set; }
    public string? Password2 { get; set; }
    public RoleEnum Role { get; set; }
}