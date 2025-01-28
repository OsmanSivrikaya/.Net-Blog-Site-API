namespace MyBlogSite.Core.Dtos.PostType;

public class PostTypeFilterDto
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string PostTypeName { get; set; } = string.Empty;
}