using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Core.Dtos.Admin.Blog;

public class BlogVisibleStatusDto
{
    [FromRoute]
    public Guid BlogId { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsVisible  { get; set; }
}