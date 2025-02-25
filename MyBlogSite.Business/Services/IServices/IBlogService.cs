using System.Linq.Expressions;
using MyBlogSite.Dal.Entity;

namespace MyBlogSite.Business.Services.IServices;

public interface IBlogService
{
    Task<bool> BeExistingBlogName(string? BlogName, CancellationToken cancellationToken = default);
    Task<bool> BeExistingSlug(string Slug);
    Task<Blog?> FirstOrDefaultAsync(Expression<Func<Blog, bool>> method, CancellationToken cancellationToken = default);
}