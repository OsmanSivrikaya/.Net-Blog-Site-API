using System.Net;
using Microsoft.AspNetCore.Mvc;
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
                switch (exception.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        await context.Response.WriteAsJsonAsync(new BadRequestObjectResult(new ResponseDto
                        {
                            Message = exception.Message,
                            Data = exception.Data is not null ? exception.Data : null,
                            ErrorCode = exception.ErrorCode
                        }));
                        break;
                    case HttpStatusCode.NotFound:
                        await context.Response.WriteAsJsonAsync(new NotFoundObjectResult(new ResponseDto
                        {
                            Message = exception.Message,
                            Data = exception.Data is not null ? exception.Data : null,
                            ErrorCode = exception.ErrorCode
                        }));
                        break;
                }
            }
        }
    }
}