using Microsoft.EntityFrameworkCore;
using MyBlogSite.Core.Dtos.Response;

namespace MyBlogSite.Business.Extensions;

public static class PaginationExtensions
{
    /// <summary>
    /// IQueryable üzerinde sayfalama işlemi yapar.
    /// </summary>
    /// <typeparam name="T">Veri tipi</typeparam>
    /// <param name="queryable">Sayfalama yapılacak sorgu</param>
    /// <param name="pageNumber">Geçerli sayfa numarası</param>
    /// <param name="pageSize">Her sayfada gösterilecek öğe sayısı</param>
    /// <returns>Sayfalanmış sonuçları içeren PaginationResult</returns>
    public static async Task<PaginationResult<T>> ToPaginationAsync<T>(
        this IQueryable<T> queryable,
        int pageNumber,
        int pageSize)
    {
        var totalCount = await queryable.CountAsync(); // Toplam kayıt sayısını al
        var items = await queryable
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(); // Sayfalama işlemini uygula

        return new PaginationResult<T>(items, pageNumber, pageSize, totalCount);
    }
}