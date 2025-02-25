using Base.Api;
using Base.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.PostType;
using MyBlogSite.Core.Dtos.Response;

namespace Admin.Controllers.v1;

[ApiVersion("1")]
[Route("admin/post-type")]
[Authorize]
public class PostTypeController(IPostTypeService postTypeService) : BaseController
{
    [HttpGet]
    public async Task<Result> GetAll([FromQuery]PostTypeFilterDto filterDto) =>
        await postTypeService.GetBlogTypesAsync(filterDto);

    [HttpGet("{id:guid}")]
    public async Task<Result> Get(Guid id) => await postTypeService.GetBlogTypeAsync(id);

    [HttpPost]
    [ValidateModel]
    [Transaction]
    public async Task<Result> Create(PostTypeCreateDto postTypeCreateDto) =>
        Result.Ok(await postTypeService.CreateAsync(postTypeCreateDto));
    
    [HttpPut("{id:guid}")]
    [ValidateModel]
    [Transaction]
    public async Task<Result> Update(Guid id, PostTypeUpdateDto postTypeUpdateDto) => Result.Ok(await postTypeService.UpdateAsync(id, postTypeUpdateDto));
    
    [HttpPut("{id:guid}/status")]
    [Transaction]
    public async Task<Result> ChangeStatus(Guid id, bool status) => await postTypeService.ChangeStatusAsync(id, status);
    
    [HttpDelete("{id:guid}/delete")]
    [Transaction]
    public async Task<Result> Delete(Guid id) => await postTypeService.PostTypeDelete(id);
}