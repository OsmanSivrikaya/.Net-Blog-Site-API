using Microsoft.AspNetCore.Http;

namespace MyBlogSite.Core.Dtos.Post;

public class PostImageCreateDto
{
    public required Guid PostId { get; set; }
    public required IFormFile File { get; set; }
}