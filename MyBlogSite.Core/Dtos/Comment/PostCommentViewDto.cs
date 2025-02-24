namespace MyBlogSite.Core.Dtos.Comment;

public class PostCommentViewDto
{
    public required Guid PostId { get; set; }
    public Guid? ParentCommentId { get; set; }
    public required string FullName { get; set; }
    public required string Content { get; set; }
}