using AutoMapper;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dtos.BlogType;

namespace MyBlogSite.Business.CustomMappping
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