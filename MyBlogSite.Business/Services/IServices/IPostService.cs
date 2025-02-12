using MyBlogSite.Core.Dtos.Post;
using MyBlogSite.Core.Dtos.Response;

namespace MyBlogSite.Business.Services.IServices;

public interface IPostService
{
    Task<Result> PostCreateAsync(PostCreateDto request);
}