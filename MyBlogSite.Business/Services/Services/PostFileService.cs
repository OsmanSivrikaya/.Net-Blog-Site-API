using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services;

public class PostFileService(IPostFileRepository postFileRepository) : IPostFileService
{
    public async Task<PostFile> CreateAsync(PostFile postFile)
    {
        return await postFileRepository.CreateAsync(postFile);
    }
}