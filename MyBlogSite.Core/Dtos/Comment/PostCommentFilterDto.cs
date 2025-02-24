namespace MyBlogSite.Core.Dtos.Comment;

public class PostCommentFilterDto
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public Guid ParentCommentId { get; set; }
    public Guid PostId { get; set; }
}