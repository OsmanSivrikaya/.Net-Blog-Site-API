using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Extensions;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Business.Services.SlugServices.Interface;
using MyBlogSite.Core.Dtos.PostType;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services
{
    public class PostTypeService(
        IPostTypeRepository postTypeRepository,
        IMapper mapper,
        ISlugService slugService) : IPostTypeService
    {
        public async Task<PostTypeViewDto> CreateAsync(PostTypeCreateDto entity)
        {
            var blogType = mapper.Map<PostType>(entity);
            blogType.Slug = await slugService.GenerateUniquePostTypeSlugAsync(blogType.TypeName);
            blogType.IsActive = true;
            blogType.IsDeleted = false;

            blogType = await postTypeRepository.CreateAsync(blogType);
            return mapper.Map<PostTypeViewDto>(blogType);
        }

        public async Task<PostTypeViewDto> UpdateAsync(Guid id, PostTypeUpdateDto entity)
        {
            var blogType = await postTypeRepository.GetByIdAsync(id);
            mapper.Map(entity, blogType);
            blogType.Slug = await slugService.GenerateUniquePostTypeSlugAsync(blogType.TypeName);
            return mapper.Map<PostTypeViewDto>(blogType);
        }

        public async Task<Result> ChangeStatusAsync(Guid id, bool status)
        {
            var blogType = await postTypeRepository.GetByIdAsync(id);

            if (blogType is null)
                Result.NotFound();

            blogType.IsActive = status;
            return Result.Ok(true);
        }

        public async Task<Result> PostTypeDelete(Guid id)
        {
            var blogType = await postTypeRepository.GetByIdAsync(id);

            if (blogType is null)
                Result.NotFound();

            blogType.IsDeleted = true;
            return Result.Ok(true);
        }

        public async Task<Result> GetBlogTypeAsync(Guid id)
        {
            var postType = await postTypeRepository.GetByIdAsync(id);
            return postType is not null ? Result.Ok(null, mapper.Map<PostTypeViewDto>(postType)) : Result.NotFound();
        }

        public async Task<Result> GetBlogTypesAsync(PostTypeFilterDto filterDto)
        {
            var query = postTypeRepository.GetAll();
            
            if (!string.IsNullOrEmpty(filterDto.PostTypeName))
                query = query.Where(x => x.TypeName.Contains(filterDto.PostTypeName));

            var blogTypes = await query
                .Where(x=> x.IsActive && !x.IsDeleted)
                .ProjectTo<PostTypeViewDto>(mapper.ConfigurationProvider)
                .ToPaginationAsync(filterDto.PageNumber, filterDto.PageSize);

            return Result.Ok(blogTypes);
        }
        public async Task<bool> BeExisting(Guid id, CancellationToken cancellationToken)
        {
            return await postTypeRepository.GetWhere(x => x.Id == id).AnyAsync(cancellationToken);
        }
        public async Task<bool> BeExistingSlug(string slug)
        {
            return await postTypeRepository.GetWhere(x => x.Slug == slug).AnyAsync();
        }
    }
}