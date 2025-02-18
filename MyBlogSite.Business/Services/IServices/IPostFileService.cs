using MyBlogSite.Dal.Entity;

namespace MyBlogSite.Business.Services.IServices;

public interface IPostFileService
{
    Task<PostFile> CreateAsync(PostFile postFile);
}