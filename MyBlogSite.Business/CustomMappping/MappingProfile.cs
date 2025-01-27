using AutoMapper;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dtos.BlogType;

namespace MyBlogSite.Business.CustomMappping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostType, BlogTypeCreateDto>().ReverseMap();
            CreateMap<UserRegisterDto, User>()
                .ForMember(dest => dest.Blog, opt => opt.MapFrom(src => src.Blog != null ? new Blog
                    {
                        BlogName = src.Blog.BlogName,
                        Description = src.Blog.Description,
                        Slug = null,
                    }
                    : null))
                .ReverseMap();
            CreateMap<UserUpdateDto, User>().ReverseMap();
            CreateMap<UserViewDto, User>().ReverseMap();
        }
    }
}