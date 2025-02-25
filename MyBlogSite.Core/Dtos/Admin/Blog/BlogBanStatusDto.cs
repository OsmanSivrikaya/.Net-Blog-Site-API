using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Core.Dtos.Admin.Blog;

public class BlogBanStatusDto
{
    [FromRoute]
    public Guid BlogId { get; set; }
    [FromBody]
    public bool IsBanned { get; set; }
}