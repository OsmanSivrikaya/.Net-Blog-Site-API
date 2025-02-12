using System.Linq.Expressions;
using MyBlogSite.Dal.Entity;

namespace MyBlogSite.Business.Services.IServices;

public interface ITagService 
{
    Task<List<Tag>> CreateRangeAsync(List<Tag> entities);
    IQueryable<Tag> GetWhere(Expression<Func<Tag, bool>> method);
}