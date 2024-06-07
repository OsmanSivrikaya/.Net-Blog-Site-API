using AutoMapper;
using MyBlogSite.Dtos.BlogType;
using MyBlogSite.Entity;

namespace MyBlogSite.WebFramework.CustomMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<BlogType, BlogTypeCreateDto>().ReverseMap();
        }
    }
}