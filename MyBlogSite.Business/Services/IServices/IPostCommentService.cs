using MyBlogSite.Core.Dtos.Comment;
using MyBlogSite.Core.Dtos.Response;

namespace MyBlogSite.Business.Services.IServices;

public interface IPostCommentService
{
    Task<Result> GetAll(PostCommentFilterDto filterDto);
    Task<Result> PostCommentCreate(PostCommentCreateDto postCommentCreateDto);
    Task<Result> PostCommentUpdate(PostCommentUpdateDto postCommentUpdateDto);
    Task<bool> BeExist(Guid id, CancellationToken cancellationToken);
    Task<Result> PostCommentDelete(Guid id);
}