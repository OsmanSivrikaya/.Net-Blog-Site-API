using Microsoft.AspNetCore.Http;
using MyBlogSite.Core.Dtos.Post;
using MyBlogSite.Core.Dtos.Response;

namespace MyBlogSite.Business.Services.IServices;

public interface IPostService
{
    Task<Result> PostCreateAsync(PostCreateDto request);
    Task<Result> PostImageAddedAsync(IFormFile formFile, Guid postId, bool isMainFile);
}