using AutoMapper;
using MyBlogSite.Dtos.BlogType;
using MyBlogSite.Entity;
using MyBlogSite.Repository.IRepository;
using MyBlogSite.Services.IServices;

namespace MyBlogSite.Services
{
    public class BlogTypeService(IBlogTypeRepository _blogTypeRepository, IMapper _mapper) : IBlogTypeService
    {
        public async Task<BlogType> CreateAsync(BlogTypeCreateDto entity){
            var blogType = _mapper.Map<BlogType>(entity);
            return await _blogTypeRepository.CreateAsync(blogType);
        }
    }
}