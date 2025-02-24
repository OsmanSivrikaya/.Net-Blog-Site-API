namespace MyBlogSite.Core.Dtos.Post;

public class PostUpdateRequestDto
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required Guid TypeId { get; set; }
    public List<UpdatePostTagDto>? PostTags { get; set; }
}
public class UpdatePostTagDto
{
    /// <summary>
    /// Var olan tag ise id verilir yeni 
    /// </summary>
    public Guid? TagId { get; set; }
    public required string Name { get; set; }
}