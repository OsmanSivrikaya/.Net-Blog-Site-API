using System.Net;

namespace Base.Exceptions
{
    /// <summary>
    /// 400 Bad Request durumunu temsil eden özel exception.
    /// </summary>
    public class BadRequestException : AppException
    {
        /// <summary>
        /// BadRequestException sınıfı için belirli bir mesajla constructor.
        /// </summary>
        public BadRequestException(string message) : base(HttpStatusCode.BadRequest, message, null) { }

        /// <summary>
        /// BadRequestException sınıfı için belirli bir mesaj ve veriyle constructor.
        /// </summary>
        public BadRequestException(string message, object? data = null) : base(HttpStatusCode.BadRequest, message, data) { }

        /// <summary>
        /// BadRequestException sınıfı için belirli bir mesaj ve hata koduyla constructor.
        /// </summary>
        public BadRequestException(string message, string? errorCode = null) : base(HttpStatusCode.BadRequest, message, errorCode) { }

        /// <summary>
        /// BadRequestException sınıfı için belirli bir mesaj, hata kodu ve veriyle constructor.
        /// </summary>
        public BadRequestException(string message, string? errorCode = null, object? data = null) : base(HttpStatusCode.BadRequest, message, errorCode, data) { }

        /// <summary>
        /// BadRequestException sınıfı için belirli bir mesaj, hata kodu ve iç hata ile constructor.
        /// </summary>
        public BadRequestException(string message, string? errorCode = null, Exception? innerException = null) : base(HttpStatusCode.BadRequest, message, errorCode, innerException) { }

        /// <summary>
        /// BadRequestException sınıfı için belirli bir mesaj, hata kodu, veri ve iç hata ile constructor.
        /// </summary>
        public BadRequestException(string message, string? errorCode = null, object? data = null, Exception? innerException = null) : base(HttpStatusCode.BadRequest, message, errorCode, data, innerException) { }
    }
}
