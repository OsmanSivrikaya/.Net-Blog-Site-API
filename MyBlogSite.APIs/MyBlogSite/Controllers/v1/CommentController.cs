using Base.Api;
using Base.Attributes;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Comment;
using MyBlogSite.Core.Dtos.Response;

namespace MyBlogSite.Controllers.v1;

[ApiVersion("1")]
[Route("comment")]
public class CommentController(IPostCommentService postCommentService) : BaseController
{
    /// <summary>
    /// Post'a atılan yorumları getirir.
    /// </summary>
    /// <param name="filterDto"></param>
    /// <returns></returns>
    [HttpGet]
    public Task<Result> GetAll([FromQuery] PostCommentFilterDto filterDto) => postCommentService.GetAll(filterDto);
    
    /// <summary>
    /// Post'a yorum atmak için kullanılır
    /// </summary>
    /// <param name="postCommentCreateDto"></param>
    /// <returns></returns>
    [ValidateModel]
    [Transaction]
    [HttpPost]
    public async Task<Result> PostCommentCreate(PostCommentCreateDto postCommentCreateDto) => await postCommentService.PostCommentCreate(postCommentCreateDto);
    
    /// <summary>
    /// Post'a atılan yorumu güncellemek için kullanılır.
    /// </summary>
    /// <param name="postCommentUpdateDto"></param>
    /// <returns></returns>
    [ValidateModel]
    [Transaction]
    [HttpPut]
    public async Task<Result> PostCommentCreate(PostCommentUpdateDto postCommentUpdateDto) => await postCommentService.PostCommentUpdate(postCommentUpdateDto);
    
    /// <summary>
    /// Post'a atılan kendi yorumunu silmek için kullanılır.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Transaction]
    [HttpDelete]
    public async Task<Result> PostCommentDelete([FromQuery]Guid id) => await postCommentService.PostCommentDelete(id);
}