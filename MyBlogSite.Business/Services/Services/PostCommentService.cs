using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Extensions;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Comment;
using MyBlogSite.Core.Dtos.PostType;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Helpers;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services;

public class PostCommentService(IPostCommentRepository postCommentRepository, IMapper mapper) : IPostCommentService
{
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

    public async Task<Result> PostCommentCreate(PostCommentCreateDto postCommentCreateDto)
    {
        var userId = ClaimHelper.GetUserId();

        var postComment = mapper.Map<PostComment>(postCommentCreateDto);
        postComment.UserId = userId;
        
        if (postCommentCreateDto.ParentCommentId != null)
        {
            var mainComment = await postCommentRepository.GetFirstAsync(x => x.Id == postCommentCreateDto.ParentCommentId);
            postComment.PostId = mainComment.PostId;
        }
        
        await postCommentRepository.CreateAsync(postComment);
        
        return Result.Ok();
    }

    public async Task<Result> PostCommentUpdate(PostCommentUpdateDto postCommentUpdateDto)
    {
        var userId = ClaimHelper.GetUserId();
        
        var postComment = await postCommentRepository.GetFirstAsync(x=> x.Id == postCommentUpdateDto.Id && x.UserId == userId);
        postComment.Content = postCommentUpdateDto.Content;
        postComment.UserId = ClaimHelper.GetUserId();
        
        return Result.Ok();
    }

    public async Task<Result> PostCommentDelete(Guid id)
    {
        var postComment = await postCommentRepository.GetFirstAsync(x => x.Id == id && x.UserId == ClaimHelper.GetUserId());
        postComment.IsDeleted = true;
        return Result.Ok();
    }
    
    public async Task<bool> BeExist(Guid id, CancellationToken cancellationToken) => await postCommentRepository.GetWhere(x => x.PostId == id).AnyAsync();
}