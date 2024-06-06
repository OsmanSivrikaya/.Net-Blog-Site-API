using MyBlogSite.Dtos.BlogType;
using MyBlogSite.Entity;

namespace MyBlogSite.Services.IServices
{
    public interface IBlogTypeService
    {
        Task<BlogType> CreateAsync(BlogTypeCreateDto entity);
    }
}