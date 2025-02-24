namespace MyBlogSite.Core.Dtos.Comment;

public class PostCommentUpdateDto
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
}