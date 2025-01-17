using Base.Attributes;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Dtos.BlogType;
using MyBlogSite.WebFramework.Api;

namespace MyBlogSite.Controllers
{
    [ApiVersion("1")]
    public class BlogTypeController(IBlogTypeService _blogTypeService) : BaseController
    {
        [HttpGet]
        public async Task<Result> GetAll(int pageNumber, int pageSize)
        {
            var result = await _blogTypeService.GetBlogTypesAsync(pageNumber, pageSize);
            if (result is not null)
                return Result.Ok(null, result);
            return Result.NotFound(null);
        }

        [HttpGet("{id}")]
        public async Task<Result> Get(Guid id)
        {
            var result = await _blogTypeService.GetBlogTypeAsync(id);
            if (result is not null)
                return Result.Ok(null, result);
            return Result.BadRequest(null);
        }

        [HttpPost]
        [ValidateModel]
        [Transaction]
        public async Task<Result> Create(BlogTypeCreateDto blogTypeCreateDto) => Result.Ok(await _blogTypeService.CreateAsync(blogTypeCreateDto));
    }
}