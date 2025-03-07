using AutoMapper;
using MyBlogSite.Core.Dtos.Admin.User;
using MyBlogSite.Core.Dtos.Comment;
using MyBlogSite.Core.Dtos.Post;
using MyBlogSite.Core.Dtos.PostType;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.Dal.Entity;

namespace MyBlogSite.Business.CustomMappping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Admin

            #region User
            
            CreateMap<User, UsersForAdminResponseDto>().ReverseMap();

            #endregion
            
            #endregion
            
            #region PostType

            CreateMap<PostType, PostTypeCreateDto>().ReverseMap();
            CreateMap<PostType, PostTypeUpdateDto>().ReverseMap();
            CreateMap<PostTypeViewDto, PostType>().ReverseMap();

            #endregion

            #region User

            CreateMap<UserRegisterDto, User>()
                .ForMember(dest => dest.Blog, opt => opt.MapFrom(src => src.Blog != null
                    ? new Blog
                    {
                        BlogName = src.Blog.BlogName,
                        Description = src.Blog.Description,
                        Slug = null,
                        IsBanned = false,
                        IsVisible = true
                    }
                    : null))
                .ReverseMap();
            CreateMap<UserUpdateDto, User>().ReverseMap();
            CreateMap<UserViewDto, User>().ReverseMap();

            #endregion
            
            #region Post
            
            CreateMap<PostCreateDto, Post>().ReverseMap();
            
            #endregion
            
            #region PostComments
            
            CreateMap<PostComment, PostCommentViewDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.Name + " " + src.User.Surname));
            CreateMap<PostCommentCreateDto, PostComment>().ReverseMap();

            #endregion
        }
    }
}