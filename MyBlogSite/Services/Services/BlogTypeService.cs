using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Data.Repository.IRepository;
using MyBlogSite.Dtos.BlogType;
using MyBlogSite.Entity;
using MyBlogSite.Services.IServices;

namespace MyBlogSite.Services.Services
{
    public class BlogTypeService(IBlogTypeRepository _blogTypeRepository, IMapper _mapper) : IBlogTypeService
    {
        public async Task<BlogType> CreateAsync(BlogTypeCreateDto entity)
        {
            var blogType = _mapper.Map<BlogType>(entity);
            return await _blogTypeRepository.CreateAsync(blogType);
        }
        public async Task<BlogType?> GetBlogTypeAsync(Guid id)
        {
            return await _blogTypeRepository.GetByIdAsync(id);
        }
        public async Task<List<BlogType>> GetBlogTypesAsync(int pageNumber, int pageSize)
        {
            var skipAmount = pageSize * (pageNumber - 1); // Sayfalamaya başlanacak kayıtın indisini hesaplar

            return await _blogTypeRepository.GetAll()
                                            .Skip(skipAmount)
                                            .Take(pageSize)
                                            .ToListAsync();
        }
    }
}