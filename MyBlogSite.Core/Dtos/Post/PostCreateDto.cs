namespace MyBlogSite.Core.Dtos.Post;

public class PostCreateDto
{
    public required Guid BlogId { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required Guid TypeId { get; set; }
    public required Guid UserId { get; set; }
    public List<PostTagDto>? PostTags { get; set; }
}

public class PostTagDto
{
    /// <summary>
    /// Var olan tag ise id verilir yeni 
    /// </summary>
    public Guid? TagId { get; set; }
    public required string Name { get; set; }
}