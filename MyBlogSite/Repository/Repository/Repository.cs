using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyBlogSite.Context;
using MyBlogSite.Entity.Abstract;
using MyBlogSite.Repository.IRepository;
using MyBlogSite.Repository.UnitofWork;
using System.Linq.Expressions;

namespace MyBlogSite.Repository.Repository
{
    public class Repository<T>(ContextDb _context) : ControllerBase, IRepository<T>, IUnitofwork where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet = _context.Set<T>();
        IDbContextTransaction _transaction = _context.Database.BeginTransaction();
        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is not null)
                _dbSet.Remove(entity);
        }
        public IQueryable<T> GetAll() => _dbSet;
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method) => _dbSet.Where(method);
        public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<T?> GetFirstAsync(Expression<Func<T, bool>> method) => await _dbSet.FirstOrDefaultAsync(method);
        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        public async Task<int> Save() => await _context.SaveChangesAsync();
        public async Task<bool> CommitAsync(bool state = true)
        {
            try
            {
                await Save();
                if (state)
                {
                    await _transaction.CommitAsync();
                }
                else
                {
                    await _transaction.RollbackAsync();
                }
                return true;
            }
            catch
            {
                await _transaction.RollbackAsync();
                return false;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
