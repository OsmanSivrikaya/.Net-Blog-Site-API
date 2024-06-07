using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.WebFramework.Api
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]// api/v1/[controller]
    public class BaseController : ControllerBase
    {
    }
}