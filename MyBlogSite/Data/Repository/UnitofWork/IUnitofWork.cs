namespace MyBlogSite.Data.Repository.UnitofWork
{  
    /// <summary>
    /// Birim of iş sınıfı, veritabanı işlemlerini yönetir ve bir transaction içinde gruplar.
    /// </summary>
    public interface IUnitofwork : IDisposable
    {
        /// <summary>
        /// Bir transaction başlatır.
        /// </summary>
        /// <returns>Başarılı olursa true, aksi halde false döner.</returns>
        Task<bool> BeginTransactionAsync();
        /// <summary>
        /// Bir transaction'ı kaydeder.
        /// </summary>
        /// <returns>Başarılı olursa true, aksi halde false döner.</returns>
        Task<bool> CommitAsync();
        /// <summary>
        /// Bir transaction'ı geri alır.
        /// </summary>
        /// <returns>Başarılı olursa true, aksi halde false döner.</returns>
        Task<bool> RollbackAsync();
    }
}
