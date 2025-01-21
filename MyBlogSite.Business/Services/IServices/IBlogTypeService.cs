using MyBlogSite.Dal.Entity;
using MyBlogSite.Dtos.BlogType;

namespace MyBlogSite.Business.Services.IServices
{
    public interface IBlogTypeService
    {
        Task<PostType> CreateAsync(BlogTypeCreateDto entity);
        Task<PostType?> GetBlogTypeAsync(Guid id);
        Task<List<PostType>> GetBlogTypesAsync(int pageNumber, int pageSize);
    }
}