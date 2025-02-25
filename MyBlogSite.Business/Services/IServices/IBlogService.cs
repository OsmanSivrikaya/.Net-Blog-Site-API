using System.Linq.Expressions;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Dal.Entity;

namespace MyBlogSite.Business.Services.IServices;

public interface IBlogService
{
    Task<Result> SetBlogBanStatusAsync(Guid blogId, bool isBan);
    Task<Result> SetVisibleStatusAsync(Guid blogId, bool isVisible, string? message = null);
    Task<Result> SetActiveStatus(Guid blogId, bool isActive);
    Task<bool> BeExistingBlogName(string? BlogName, CancellationToken cancellationToken = default);
    Task<bool> BeExistingSlug(string Slug);
    Task<Blog?> FirstOrDefaultAsync(Expression<Func<Blog, bool>> method, CancellationToken cancellationToken = default);
}