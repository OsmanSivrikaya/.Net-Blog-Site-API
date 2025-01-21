using Microsoft.EntityFrameworkCore.Storage;

namespace MyBlogSite.Dal.Repository.UnitofWork
{
    /// <summary>
    /// Birim of iş sınıfı, veritabanı işlemlerini yönetir ve bir transaction içinde gruplar.
    /// </summary>
    public class UnitOfWork(ContextDb _context) : IUnitofwork
    {
        private IDbContextTransaction? _transaction;

        /// <summary>
        /// Bir transaction başlatır.
        /// </summary>
        /// <returns>Başarılı olursa true, aksi halde false döner.</returns>
        public async Task<bool> BeginTransactionAsync()
        {
            if (_transaction == null)
                _transaction = await _context.Database.BeginTransactionAsync();
            return _transaction != null;
        }

        /// <summary>
        /// Bir transaction'ı kaydeder.
        /// </summary>
        /// <returns>Başarılı olursa true, aksi halde false döner.</returns>
        public async Task<bool> CommitAsync()
        {
            try
            {
                if (_transaction != null)
                    await _transaction.CommitAsync();
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                await RollbackAsync();
                return false;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Bir transaction'ı geri alır.
        /// </summary>
        /// <returns>Başarılı olursa true, aksi halde false döner.</returns>
        public async Task<bool> RollbackAsync()
        {
            try
            {
                if (_transaction != null)
                    await _transaction.RollbackAsync();
                return true;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// UnitOfWork sınıfının kaynaklarını temizler.
        /// </summary>
        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
