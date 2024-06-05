using System.Linq.Expressions;

namespace MyBlogSite.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T?> GetFirstAsync(Expression<Func<T, bool>> method);
        Task<T?> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        T Update(T entity);
    }
}

