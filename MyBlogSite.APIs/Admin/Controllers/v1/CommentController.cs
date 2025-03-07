﻿using Base.Api;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Comment;
using MyBlogSite.Core.Dtos.Response;

namespace Admin.Controllers.v1;

[ApiVersion("1")]
[Route("admin/comment")]
public class CommentController(IPostCommentService postCommentService) : BaseController
{
    /// <summary>
    /// Post'a atılan yorumları getirir.
    /// </summary>
    /// <param name="filterDto"></param>
    /// <returns></returns>
    [HttpGet]
    public Task<Result> GetAll([FromQuery] PostCommentFilterDto filterDto) => postCommentService.GetAll(filterDto);
}