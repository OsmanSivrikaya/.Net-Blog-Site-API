namespace MyBlogSite.Core.Dtos.PostType;

public class PostTypeViewDto
{
    public required Guid Id { get; set; }
    public required string TypeName { get; set; }
    public required string Slug { get; set; }
}