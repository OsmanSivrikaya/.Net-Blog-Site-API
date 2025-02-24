using Base.Api;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Comment;
using MyBlogSite.Core.Dtos.Response;

namespace MyBlogSite.Controllers.v1;

[ApiVersion("1")]
[Route("comment")]
public class CommentController(IPostCommentService postCommentService) : BaseController
{
    [HttpGet]
    public Task<Result> GetAll([FromQuery] PostCommentFilterDto filterDto) => postCommentService.GetAll(filterDto);
    
}