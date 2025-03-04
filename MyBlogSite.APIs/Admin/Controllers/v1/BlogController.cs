using Base.Api;
using Base.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Admin.Blog;
using MyBlogSite.Core.Dtos.Response;

namespace Admin.Controllers.v1;

[ApiVersion("1")]
[Route("admin/blog")]
public class BlogController(IBlogService blogService) : BaseController
{
    /// <summary>
    /// Blog engellemek için kullanılır.
    /// Dikkat blog engellendiğinde tüm kullanıcılarda engellenir
    /// </summary>
    /// <param name="blogBanStatusDto"></param>
    /// <returns></returns>
    [Authorize]
    [Transaction]
    [HttpPost("ban-blog/{BlogId}")]
    public async Task<Result> BanBlog(BlogBanStatusDto blogBanStatusDto) =>
        await blogService.SetBlogBanStatusAsync(blogBanStatusDto.BlogId, blogBanStatusDto.IsBanned);

    /// <summary>
    /// Blog görünürlüğünü kapatmak için kullanılır.
    /// Eğer istenilir ise görünürlük kapatma nedeni message ile bildirim olarak gönderilir.
    /// </summary>
    /// <param name="blogVisibleStatusDto"></param>
    /// <returns></returns>
    [Authorize]
    [Transaction]
    [HttpPut("ban-blog/{BlogId}")]
    public async Task<Result> SetVisibleStatus(BlogVisibleStatusDto blogVisibleStatusDto) =>
        await blogService.SetVisibleStatusAsync(blogVisibleStatusDto.BlogId, blogVisibleStatusDto.IsVisible,
            blogVisibleStatusDto.Message);
    
    /// <summary>
    /// Blog aktifliğini kaldırmak için kullanılır.
    /// Dikkat aktfiliği kaldırılan blog'a bağlı olan kullanıcılarında ilişkisi kaldırılır.
    /// </summary>
    /// <param name="blogId"></param>
    /// <param name="activeStatus"></param>
    /// <returns></returns>
    [Authorize]
    [Transaction]
    [HttpDelete("{blogId}")]
    public async Task<Result> SetActiveStatus([FromRoute]Guid blogId, [FromQuery]bool activeStatus) =>
        await blogService.SetActiveStatus(blogId, activeStatus);
}