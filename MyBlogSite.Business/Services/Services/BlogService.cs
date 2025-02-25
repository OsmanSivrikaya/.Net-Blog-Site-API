using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services;

public class BlogService(IBlogRepository blogRepository) : IBlogService
{
    public async Task<bool> BeExistingBlogName(string? blogName, CancellationToken cancellationToken = default)
    {
        var result = !await blogRepository.GetWhere(x => x.BlogName == blogName).AnyAsync(cancellationToken);
        return result;
    }

    public async Task<Blog?> FirstOrDefaultAsync(Expression<Func<Blog, bool>> method,
        CancellationToken cancellationToken = default)
    {
        return await blogRepository.GetFirstAsync(method, cancellationToken);
    }
    public async Task<bool> BeExistingSlug(string slug)
    {
        return await blogRepository.GetWhere(x => x.Slug == slug).AnyAsync();
    }
}