using AutoMapper;
using MyBlogSite.Dtos.BlogType;
using MyBlogSite.Dtos.User;
using MyBlogSite.Entity;

namespace MyBlogSite.WebFramework.CustomMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<BlogType, BlogTypeCreateDto>().ReverseMap();
            CreateMap<UserCreateDto, User>().ReverseMap();
            CreateMap<UserViewDto, User>().ReverseMap();
        }
    }
}