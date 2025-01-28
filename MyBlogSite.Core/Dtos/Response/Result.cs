using System.Net;

namespace MyBlogSite.Core.Dtos.Response
{
    /// <summary>
    /// API yanıtlarını standartlaştırmak için kullanılan DTO (Data Transfer Object) sınıfı.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Yanıt türünü belirten URL.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// İşlemin başarılı olup olmadığını belirten bayrak.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// İşlemle ilgili mesaj.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Yanıtla birlikte dönen veri.
        /// </summary>
        public object? Data { get; set; }

        /// <summary>
        /// Hata kodu (varsa).
        /// </summary>
        public string? ErrorCode { get; set; }

        /// <summary>
        /// HTTP durum kodu.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// İlgili hata durumunda yığın izleme bilgileri (isteğe bağlı).
        /// </summary>
        public string? StackTrace { get; set; }

        /// <summary>
        /// Başarılı bir 200 OK yanıtı döner
        /// </summary>
        /// <returns></returns>
        public static Result Ok()
        {
            return new Result
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-200-ok",
                IsSuccess = true,
                Message = "Success",
                Data = null,
                StatusCode = (int)HttpStatusCode.OK
            };
        }
        
        /// <summary>
        /// Başarılı bir 200 OK yanıtı döner.
        /// </summary>
        /// <param name="data">Yanıtla birlikte dönen veri.</param>
        /// <returns>JsonResult ile dönen 200 OK yanıtı.</returns>
        public static Result Ok(object? data = null)
        {
            return new Result
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-200-ok",
                IsSuccess = true,
                Message = "Success",
                Data = data,
                StatusCode = (int)HttpStatusCode.OK
            };
        }
        /// <summary>
        /// Başarılı bir 200 OK yanıtı döner.
        /// </summary>
        /// <param name="message">İşlemle ilgili mesaj (varsayılan: "Success").</param>
        /// <param name="data">Yanıtla birlikte dönen veri.</param>
        /// <returns>JsonResult ile dönen 200 OK yanıtı.</returns>
        public static Result Ok(string? message = null, object? data = null)
        {
            return new Result
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-200-ok",
                IsSuccess = true,
                Message = message ?? "Success",
                Data = data,
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Hatalı bir 400 Bad Request yanıtı döner.
        /// </summary>
        /// <param name="data">Yanıtla birlikte dönen veri.</param>
        /// <param name="errorCode">Hata kodu.</param>
        /// <returns>JsonResult ile dönen 400 Bad Request yanıtı.</returns>
        public static Result BadRequest(object? data = null, string? errorCode = null, string? stackTrace = null)
        {
            return new Result
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-400-bad-request",
                IsSuccess = false,
                Message = "Error",
                Data = data,
                ErrorCode = errorCode,
                StatusCode = (int)HttpStatusCode.BadRequest,
                StackTrace = stackTrace
            };
        }
        /// <summary>
        /// Hatalı bir 400 Bad Request yanıtı döner.
        /// </summary>
        /// <param name="message">Hata mesajı (varsayılan: "Error").</param>
        /// <param name="data">Yanıtla birlikte dönen veri.</param>
        /// <param name="errorCode">Hata kodu.</param>
        /// <returns>JsonResult ile dönen 400 Bad Request yanıtı.</returns>
        public static Result BadRequest(string? message = null, object? data = null, string? errorCode = null, string? stackTrace = null)
        {
            return new Result
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-400-bad-request",
                IsSuccess = false,
                Message = message ?? "Error",
                Data = data,
                ErrorCode = errorCode,
                StatusCode = (int)HttpStatusCode.BadRequest,
                StackTrace = stackTrace
            };
        }
        
        /// <summary>
        /// Hatalı bir 404 Not Found yanıtı döner.
        /// </summary>
        /// <returns></returns>
        public static Result NotFound()
        {
            return new Result
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-404-not-found",
                IsSuccess = false,
                Message = "Error",
                Data = null,
                ErrorCode = null,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }
        
        /// <summary>
        /// Hatalı bir 404 Not Found yanıtı döner.
        /// </summary>
        /// <param name="data">Yanıtla birlikte dönen veri.</param>
        /// <param name="errorCode">Hata kodu.</param>
        /// <returns>JsonResult ile dönen 404 Not Found yanıtı.</returns>
        public static Result NotFound(object? data = null, string? errorCode = null)
        {
            return new Result
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-404-not-found",
                IsSuccess = false,
                Message = "Error",
                Data = data,
                ErrorCode = errorCode,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }
        /// <summary>
        /// Hatalı bir 404 Not Found yanıtı döner.
        /// </summary>
        /// <param name="message">Hata mesajı (varsayılan: "Error").</param>
        /// <param name="data">Yanıtla birlikte dönen veri.</param>
        /// <param name="errorCode">Hata kodu.</param>
        /// <returns>JsonResult ile dönen 404 Not Found yanıtı.</returns>
        public static Result NotFound(string? message = null, object? data = null, string? errorCode = null)
        {
            return new Result()
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-404-not-found",
                IsSuccess = false,
                Message = message ?? "Error",
                Data = data,
                ErrorCode = errorCode,
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        /// <summary>
        /// Hatalı bir 401 Not Found yanıtı döner.
        /// </summary>
        /// <returns>JsonResult ile dönen 401 Unauthorized yanıtı.</returns>
        public static Result Unauthorized()
        {
            return new Result()
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-401-unauthorized",
                IsSuccess = false,
                Message = "İzin Verme hatası: Geçersiz yetkilendirme bilgileri.",
                Data = null,
                ErrorCode = null,
                StatusCode = (int)HttpStatusCode.Unauthorized
            };
        }
    }
}
