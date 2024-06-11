using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Dtos.Response;
using MyBlogSite.Services.IServices;
using MyBlogSite.WebFramework.Api;

namespace MyBlogSite.Controllers
{
    [ApiVersion("1")]
    public class BlogTypeController(IBlogTypeService _blogTypeService) : BaseController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _blogTypeService.GetAllBlogTypeAsync().Result;
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
    }
}