using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Core.Dtos.Admin.User;

public class UserBanStatusDto
{
    [FromRoute]
    public Guid UserId { get; set; }
    [FromBody]
    public bool IsBanned { get; set; }
}