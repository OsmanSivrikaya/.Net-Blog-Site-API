using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services;

public class BlogService(IBlogRepository blogRepository) : IBlogService
{
    public async Task<bool> BeExistingBlogName(string? blogName, CancellationToken cancellationToken = default)
    {
        var result = !await blogRepository.GetWhere(x => x.BlogName == blogName).AnyAsync(cancellationToken);
        return result;
    }
    public async Task<bool> BeExistingSlug(string slug)
    {
        return await blogRepository.GetWhere(x => x.Slug == slug).AnyAsync();
    }
}