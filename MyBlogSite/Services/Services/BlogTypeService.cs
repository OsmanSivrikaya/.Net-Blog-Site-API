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
        public async Task<BlogType> CreateAsync(BlogTypeCreateDto entity){
            var blogType = _mapper.Map<BlogType>(entity);
            return await _blogTypeRepository.CreateAsync(blogType);
        }
        public async Task<BlogType?> GetBlogTypeAsync(Guid id){
            return await _blogTypeRepository.GetByIdAsync(id);
        }
        public async Task<List<BlogType>> GetAllBlogTypeAsync(){
            return await _blogTypeRepository.GetAll().ToListAsync();
        }
    }
}