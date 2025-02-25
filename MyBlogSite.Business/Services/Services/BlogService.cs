using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.ProducerDtos;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Enums;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services;

public class BlogService(
    IBlogRepository blogRepository,
    IUserRepository userRepository,
    INotificationService notificationService) : IBlogService
{
    public async Task<Result> SetBlogBanStatusAsync(Guid blogId, bool isBan)
    {
        var blog = await blogRepository
            .GetWhere(x => x.Id == blogId)
            .Include(x => x.Users)
            .FirstOrDefaultAsync();

        if (blog is null)
            return Result.NotFound("Blog bulunamadı!");

        blog.IsBanned = isBan;
        blog.Users.ForEach(x => x.IsBanned = isBan);

        blogRepository.Update(blog);
        userRepository.UpdateRange(blog.Users);

        return Result.Ok("İşlem gerçekleştirildi.");
    }

    public async Task<Result> SetVisibleStatusAsync(Guid blogId, bool isVisible, string? message = null)
    {
        var blog = await blogRepository
            .GetWhere(x => x.Id == blogId)
            .Include(x => x.Users)
            .FirstOrDefaultAsync();

        if (blog is null)
            return Result.NotFound("Blog bulunamadı!");

        blog.IsVisible = isVisible;

        if (message != null)
            await notificationService.SendNotificationQueueAsync(new NotificationMessageDto
            {
                Message = message,
                UserIds = blog.Users.Select(x => x.Id).ToList(),
                Type = NotificationTypeEnum.BlogVisibleStatusChanged
            });

        return Result.Ok("İşlem gerçekleştirildi.");
    }
    
    public async Task<Result> SetActiveStatus(Guid blogId, bool isActive)
    {
        var blog = await blogRepository
            .GetWhere(x => x.Id == blogId)
            .Include(x => x.Users)
            .FirstOrDefaultAsync();

        if (blog is null)
            return Result.NotFound("Blog bulunamadı!");

        blog.IsActive = isActive;
        blog.FounderUserId = null;
        
        blog.Users.ForEach(x => x.BlogId = null);

        blogRepository.Update(blog);
        userRepository.UpdateRange(blog.Users);

        return Result.Ok("İşlem gerçekleştirildi.");
    }

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