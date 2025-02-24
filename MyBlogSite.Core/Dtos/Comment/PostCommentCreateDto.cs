namespace MyBlogSite.Core.Dtos.Comment;

public class PostCommentCreateDto
{
    public Guid? PostId { get; set; }
    public Guid? ParentCommentId { get; set; }
    public required string Content { get; set; }
}