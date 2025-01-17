using MyBlogSite.Dal.Entity;
using MyBlogSite.Dtos.BlogType;

namespace MyBlogSite.Business.Services.IServices
{
    public interface IBlogTypeService
    {
        Task<BlogType> CreateAsync(BlogTypeCreateDto entity);
        Task<BlogType?> GetBlogTypeAsync(Guid id);
        Task<List<BlogType>> GetBlogTypesAsync(int pageNumber, int pageSize);
    }
}