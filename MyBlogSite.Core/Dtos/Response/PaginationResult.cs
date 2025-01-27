namespace MyBlogSite.Core.Dtos.Response;

public class PaginationResult<T>(IEnumerable<T> items, int pageNumber, int pageSize, int totalCount)
{
    /// <summary>
    /// Geçerli sayfa numarasını temsil eder.
    /// </summary>
    private int CurrentPage { get; set; } = pageNumber;

    /// <summary>
    /// Her sayfada gösterilecek öğe sayısını temsil eder.
    /// </summary>
    public int PageSize { get; private set; } = pageSize;

    /// <summary>
    /// Toplam kayıt sayısını temsil eder.
    /// </summary>
    public int TotalCount { get; private set; } = totalCount;

    /// <summary>
    /// Toplam sayfa sayısını temsil eder.
    /// </summary>
    private int TotalPages { get; set; } = (int)Math.Ceiling(totalCount / (double)pageSize);

    /// <summary>
    /// Sayfalanmış öğeleri temsil eder.
    /// </summary>
    public IQueryable<T> Items { get; private set; } = items.AsQueryable(); // Öğeleri sorgu haline getir

    /// <summary>
    /// Geçerli sayfadan sonraki bir sayfa olup olmadığını belirler.
    /// </summary>
    public bool HasNext => CurrentPage < TotalPages;
}