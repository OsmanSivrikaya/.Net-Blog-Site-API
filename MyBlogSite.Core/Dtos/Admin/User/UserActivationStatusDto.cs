using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Core.Dtos.Admin.User;

public class UserActivationStatusDto
{
    [FromBody]
    public bool IsActive { get; set; }
    [FromRoute]
    public Guid UserId { get; set; }
}