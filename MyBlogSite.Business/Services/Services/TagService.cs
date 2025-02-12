using System.Linq.Expressions;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services;

public class TagService(ITagRepository tagRepository) : ITagService
{
    public async Task<List<Tag>> CreateRangeAsync(List<Tag> entities)
    {
        return await tagRepository.CreateRangeAsync(entities);
    }

    public IQueryable<Tag> GetWhere(Expression<Func<Tag, bool>> method)
    {
        return tagRepository.GetWhere(method);
    }
}