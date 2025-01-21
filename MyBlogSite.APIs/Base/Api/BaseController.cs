using Microsoft.AspNetCore.Mvc;

namespace Base.Api
{
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    public class BaseController : ControllerBase
    {
    }
}