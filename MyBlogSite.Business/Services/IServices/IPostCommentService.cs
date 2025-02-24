using MyBlogSite.Core.Dtos.Comment;
using MyBlogSite.Core.Dtos.Response;

namespace MyBlogSite.Business.Services.IServices;

public interface IPostCommentService
{
    Task<Result> GetAll(PostCommentFilterDto filterDto);
}