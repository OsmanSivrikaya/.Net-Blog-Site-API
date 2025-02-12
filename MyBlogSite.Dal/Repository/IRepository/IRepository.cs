using System.Linq.Expressions;

namespace MyBlogSite.Dal.Repository.IRepository;

/// <summary>
/// Genel veri tabanı işlemleri için kullanılan genel bir arayüz.
/// </summary>
/// <typeparam name="T">Veritabanında işlenecek varlık türü.</typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Tüm varlıkları sorgusuz bir şekilde getirir.
    /// </summary>
    /// <returns>Tüm varlıkların sorgusuz koleksiyonu.</returns>
    IQueryable<T> GetAll();

    /// <summary>
    /// Belirli bir koşula göre filtrelenmiş varlıkları getirir.
    /// </summary>
    /// <param name="method">Filtreleme koşulu.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Filtrelenmiş varlık koleksiyonu.</returns>
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method);

    /// <summary>
    /// Belirli bir koşula göre filtrelenmiş ilk varlığı asenkron olarak getirir.
    /// </summary>
    /// <param name="method">Filtreleme koşulu.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Filtrelenmiş ilk varlık.</returns>
    Task<T?> GetFirstAsync(Expression<Func<T, bool>> method, CancellationToken cancellationToken = default);

    /// <summary>
    /// Belirli bir kimliğe sahip varlığı asenkron olarak getirir.
    /// </summary>
    /// <param name="id">Getirilecek varlığın kimliği.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Belirtilen kimliğe sahip varlık.</returns>
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Yeni bir varlık oluşturur ve veritabanına ekler.
    /// </summary>
    /// <param name="entity">Eklenecek varlık.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Eklendiği varlık.</returns>
    Task<T> CreateAsync(T entity);

    /// <summary>
    /// List olarak yeni bir varlık oluşturur ve veritabanına ekler.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task<List<T>> CreateRangeAsync(List<T> entities);
    
    /// <summary>
    /// Birden fazla varlık oluşturur ve veritabanına ekler.
    /// </summary>
    /// <param name="entities">Eklenecek varlıkların koleksiyonu.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Eklendiği varlık koleksiyonu.</returns>
    Task<IEnumerable<T>> CreateAsync(List<T> entities);

    /// <summary>
    /// Belirtilen bir varlığı veritabanından siler.
    /// </summary>
    /// <param name="id">Silinecek varlığın kimliği.</param>
    /// <param name="cancellationToken"></param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Bir varlığı günceller.
    /// </summary>
    /// <param name="entity">Güncellenecek varlık.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Güncellenen varlık.</returns>
    T Update(T entity);
    
    /// <summary>
    /// list şeklindeki varlıkları günceller
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    List<T> UpdateRange(List<T> entities);
}