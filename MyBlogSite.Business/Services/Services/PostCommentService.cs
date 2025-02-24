using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Extensions;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Comment;
using MyBlogSite.Core.Dtos.PostType;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services;

public class PostCommentService(IPostCommentRepository postCommentRepository, IMapper mapper) : IPostCommentService
{
    [HttpGet]
    public async Task<Result> GetAll(PostCommentFilterDto filterDto)
    {
        var query = postCommentRepository.GetWhere(x=> x.PostId == filterDto.PostId);
            
        if (filterDto.ParentCommentId != Guid.Empty)
            query = query.Where(x => x.ParentCommentId == filterDto.ParentCommentId);

        var postComments = await query
            .Where(x=> !x.IsDeleted)
            .Include(x=> x.User)
            .ProjectTo<PostCommentViewDto>(mapper.ConfigurationProvider)
            .ToPaginationAsync(filterDto.PageNumber, filterDto.PageSize);

        return Result.Ok(postComments);
    }
}