using System.Net;

namespace MyBlogSite.Common.Exceptions
{
    /// <summary>
    /// 404 Not Found durumunu temsil eden özel exception.
    /// </summary>
    public class NotFoundException : AppException
    {
        /// <summary>
        /// NotFoundException sınıfı için belirli bir mesajla constructor.
        /// </summary>
        public NotFoundException(string message) : base(HttpStatusCode.NotFound, message, null) { }

        /// <summary>
        /// NotFoundException sınıfı için belirli bir mesaj ve veriyle constructor.
        /// </summary>
        public NotFoundException(string message, object? data = null) : base(HttpStatusCode.NotFound, message, data) { }

        /// <summary>
        /// NotFoundException sınıfı için belirli bir mesaj ve hata koduyla constructor.
        /// </summary>
        public NotFoundException(string message, string? errorCode = null) : base(HttpStatusCode.NotFound, message, errorCode) { }

        /// <summary>
        /// NotFoundException sınıfı için belirli bir mesaj, hata kodu ve veriyle constructor.
        /// </summary>
        public NotFoundException(string message, string? errorCode = null, object? data = null) : base(HttpStatusCode.NotFound, message, errorCode, data) { }

        /// <summary>
        /// NotFoundException sınıfı için belirli bir mesaj, hata kodu ve iç hata ile constructor.
        /// </summary>
        public NotFoundException(string message, string? errorCode = null, Exception? innerException = null) : base(HttpStatusCode.NotFound, message, errorCode, innerException) { }

        /// <summary>
        /// NotFoundException sınıfı için belirli bir mesaj, hata kodu, veri ve iç hata ile constructor.
        /// </summary>
        public NotFoundException(string message, string? errorCode = null, object? data = null, Exception? innerException = null) : base(HttpStatusCode.NotFound, message, errorCode, data, innerException) { }
    }
}
