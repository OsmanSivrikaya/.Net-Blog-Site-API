using MyBlogSite.Common.Exceptions;
using MyBlogSite.Dtos.Response;
using Serilog;

namespace MyBlogSite.WebFramework.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (AppException exception)
            {
                Log.Error(exception, exception.Message);
                context.Response.StatusCode = (int)exception.StatusCode;
                await context.Response.WriteAsJsonAsync(new ResponseDto
                {
                    Message = exception.Message,
                    Data = exception.Data is not null ? exception.Data : null,
                    ErrorCode = exception.ErrorCode,
                    StatusCode = (int)exception.StatusCode
                });
            }
        }
    }
}