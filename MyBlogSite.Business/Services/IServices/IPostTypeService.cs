using MyBlogSite.Core.Dtos.PostType;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Dal.Entity;

namespace MyBlogSite.Business.Services.IServices
{
    public interface IPostTypeService
    {
        Task<PostTypeViewDto> CreateAsync(PostTypeCreateDto entity);
        Task<PostTypeViewDto> UpdateAsync(Guid id, PostTypeUpdateDto entity);
        Task<Result> ChangeStatusAsync(Guid id, bool status);
        Task<Result> PostTypeDelete(Guid id);
        Task<Result> GetBlogTypeAsync(Guid id);
        Task<Result> GetBlogTypesAsync(PostTypeFilterDto filterDto);
        Task<bool> BeExistingSlug(string slug);
    }
}