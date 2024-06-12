using MyBlogSite.Dtos.BlogType;
using MyBlogSite.Entity;

namespace MyBlogSite.Services.IServices
{
    public interface IBlogTypeService
    {
        Task<BlogType> CreateAsync(BlogTypeCreateDto entity);
        Task<BlogType?> GetBlogTypeAsync(Guid id);
        Task<List<BlogType>> GetBlogTypesAsync(int pageNumber, int pageSize);
    }
}