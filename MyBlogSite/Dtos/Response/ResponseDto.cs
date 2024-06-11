using Microsoft.AspNetCore.Mvc;

namespace MyBlogSite.Dtos.Response
{
    public class ResponseDto
    {
        public string? Type { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public string? ErrorCode { get; set; }

        public static IActionResult Ok(string? message = null, object? data = null)
        {
            return new OkObjectResult(new ResponseDto
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-200-ok",
                Success = true,
                Message = "Success",
                Data = data,
            });
        }

        public static IActionResult BadRequest(string? message = null, object? data = null, string? errorCode = null)
        {
            return new BadRequestObjectResult(new ResponseDto
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-400-bad-request",
                Success = false,
                Message = message ?? "Error",
                Data = data,
                ErrorCode = errorCode
            });
        }

        public static IActionResult NotFound(string? message = null, object? data = null, string? errorCode = null)
        {
            return new NotFoundObjectResult(new ResponseDto
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-404-not-found",
                Success = false,
                Message = message ?? "Error",
                Data = data,
                ErrorCode = errorCode
            });
        }
    }
}
