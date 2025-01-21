namespace MyBlogSite.Business.Services.IServices;

public interface IBlogService
{
    Task<bool> BeExistingBlogName(string? BlogName, CancellationToken cancellationToken = default);
    Task<bool> BeExistingSlug(string Slug);
}