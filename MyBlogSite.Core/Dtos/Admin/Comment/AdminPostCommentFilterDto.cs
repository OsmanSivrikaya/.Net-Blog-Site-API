namespace MyBlogSite.Core.Dtos.Admin.Comment;

public class AdminPostCommentFilterDto
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public Guid ParentCommentId { get; set; }
    public Guid PostId { get; set; }
}