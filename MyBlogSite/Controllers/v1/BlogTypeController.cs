using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Dtos.BlogType;
using MyBlogSite.Dtos.Response;
using MyBlogSite.Services.IServices;
using MyBlogSite.WebFramework.Api;
using MyBlogSite.WebFramework.Attributes;

namespace MyBlogSite.Controllers
{
    [ApiVersion("1")]
    public class BlogTypeController(IBlogTypeService _blogTypeService) : BaseController
    {
        [HttpGet]
        public IActionResult GetAll(int pageNumber, int pageSize)
        {
            var result = _blogTypeService.GetBlogTypesAsync(pageNumber, pageSize).Result;
            if (result is not null)
                return ResponseDto.Ok(null, result);
            return ResponseDto.NotFound(null);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _blogTypeService.GetBlogTypeAsync(id).Result;
            if (result is not null)
                return ResponseDto.Ok(null, result);
            return ResponseDto.BadRequest(null);
        }

        [HttpPost]
        [ValidateModel]
        [Transaction]
        public IActionResult Create(BlogTypeCreateDto blogTypeCreateDto) => ResponseDto.Ok(_blogTypeService.CreateAsync(blogTypeCreateDto).Result);
    }
}