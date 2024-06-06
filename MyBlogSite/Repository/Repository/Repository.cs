using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Context;
using MyBlogSite.Entity.Abstract;
using MyBlogSite.Repository.IRepository;
using System.Linq.Expressions;

namespace MyBlogSite.Repository.Repository
{
    /// <summary>
    /// Genel veri tabanı işlemleri için kullanılan genel bir repository.
    /// </summary>
    /// <typeparam name="T">Veritabanında işlenecek varlık türü.</typeparam>
    public class Repository<T>(ContextDb _context) : ControllerBase, IRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet = _context.Set<T>();

        /// <summary>
        /// Yeni bir varlık oluşturur ve veritabanına ekler.
        /// </summary>
        /// <param name="entity">Eklenecek varlık.</param>
        /// <returns>Eklendiği varlık.</returns>
        public async Task<T> CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await _dbSet.AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// Birden fazla varlık oluşturur ve veritabanına ekler.
        /// </summary>
        /// <param name="entities">Eklenecek varlıkların koleksiyonu.</param>
        /// <returns>Eklendiği varlık koleksiyonu.</returns>
        public async Task<IEnumerable<T>> CreateAsync(IEnumerable<T> entities)
        {
            var currentDate = DateTime.UtcNow;
            foreach (var entity in entities)
            {
                entity.CreatedDate = currentDate;
            }

            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        /// <summary>
        /// Belirtilen bir varlığı veritabanından siler.
        /// </summary>
        /// <param name="id">Silinecek varlığın kimliği.</param>
        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        /// <summary>
        /// Tüm varlıkları sorgusuz bir şekilde getirir.
        /// </summary>
        /// <returns>Tüm varlıkların sorgusuz koleksiyonu.</returns>
        public IQueryable<T> GetAll() => _dbSet.AsNoTracking();

        /// <summary>
        /// Belirli bir koşula göre filtrelenmiş varlıkları getirir.
        /// </summary>
        /// <param name="method">Filtreleme koşulu.</param>
        /// <returns>Filtrelenmiş varlık koleksiyonu.</returns>
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method) => _dbSet.AsNoTracking().Where(method);

        /// <summary>
        /// Belirli bir kimliğe sahip varlığı asenkron olarak getirir.
        /// </summary>
        /// <param name="id">Getirilecek varlığın kimliği.</param>
        /// <returns>Belirtilen kimliğe sahip varlık.</returns>
        public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        /// <summary>
        /// Belirli bir koşula göre filtrelenmiş ilk varlığı asenkron olarak getirir.
        /// </summary>
        /// <param name="method">Filtreleme koşulu.</param>
        /// <returns>Filtrelenmiş ilk varlık.</returns>
        public async Task<T?> GetFirstAsync(Expression<Func<T, bool>> method) => await _dbSet.FirstOrDefaultAsync(method);

        /// <summary>
        /// Bir varlığı günceller.
        /// </summary>
        /// <param name="entity">Güncellenecek varlık.</param>
        /// <returns>Güncellenen varlık.</returns>
        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
