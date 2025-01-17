using Base.Exceptions;
using MyBlogSite.Core.Dtos.Response;
using Serilog;

namespace Base.Middlewares
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
                await context.Response.WriteAsJsonAsync(new Result
                {
                    Message = exception.Message,
                    Data = exception.Data,
                    ErrorCode = exception.ErrorCode,
                    StatusCode = (int)exception.StatusCode
                });
            }
        }
    }
}