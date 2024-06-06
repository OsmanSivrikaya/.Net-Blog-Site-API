using AutoMapper;
using MyBlogSite.Dtos.BlogType;
using MyBlogSite.Entity;

namespace MyBlogSite.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<BlogType, BlogTypeCreateDto>().ReverseMap();
        }
    }
}