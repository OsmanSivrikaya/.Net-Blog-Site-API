using Base.Api;
using Base.Attributes;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Post;
using MyBlogSite.Core.Dtos.Response;

namespace MyBlogSite.Controllers.v1;

[ApiVersion("1")]
[Route("post")]
public class PostController(IPostService postService) : BaseController
{
    /// <summary>
    /// Blog için bir post oluşturmada kullanılır. 
    /// </summary>
    /// <param name="postCreateDto">postCreateDto içerisinde PostTagDto nesnesi verilir list şeklinde ve verilen
    /// bu listede taglar id'siz ise yenileri id'li ise var olanlar ile bağlantı kurulur. </param>
    /// <returns></returns>
    [ValidateModel]
    [Transaction]
    [HttpPost]
    public async Task<Result> PostCreateAsync(PostCreateDto postCreateDto) =>
        await postService.PostCreateAsync(postCreateDto);
}