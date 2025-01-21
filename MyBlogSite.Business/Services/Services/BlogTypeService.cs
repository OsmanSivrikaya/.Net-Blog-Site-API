using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;
using MyBlogSite.Dtos.BlogType;

namespace MyBlogSite.Business.Services.Services
{
    public class BlogTypeService(IPostTypeRepository postTypeRepository, IMapper _mapper) : IBlogTypeService
    {
        public async Task<PostType> CreateAsync(BlogTypeCreateDto entity)
        {
            var blogType = _mapper.Map<PostType>(entity);
            return await postTypeRepository.CreateAsync(blogType);
        }
        public async Task<PostType?> GetBlogTypeAsync(Guid id)
        {
            return await postTypeRepository.GetByIdAsync(id);
        }
        public async Task<List<PostType>> GetBlogTypesAsync(int pageNumber, int pageSize)
        {
            var skipAmount = pageSize * (pageNumber - 1); // Sayfalamaya başlanacak kayıtın indisini hesaplar

            return await postTypeRepository.GetAll()
                                            .Skip(skipAmount)
                                            .Take(pageSize)
                                            .ToListAsync();
        }
    }
}