using System.Net;

namespace Base.Exceptions
{
    /// <summary>
    /// Uygulamanın temel özel exception sınıfı.
    /// </summary>
    public class AppException : Exception
    {
        private object? data;
        /// <summary>
        /// Hata kodu özelliği eklendi, isteğe bağlı olarak null olabilir.
        /// </summary>
        public string? ErrorCode { get; }
        /// <summary>
        /// Status kodu belirtir. 
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Özel veri (nesne) taşımak için Data özelliği eklendi.
        /// </summary>
        public object? GetData() => data;
        /// <summary>
        /// Özel veri (nesne) taşımak için Data özelliği eklendi.
        /// </summary>
        public void SetData(object? value) => data = value;

        /// <summary>
        /// AppException sınıfının varsayılan constructor'ı.
        /// </summary>
        public AppException() : base() { }

        /// <summary>
        /// AppException sınıfı için message ve data belirtilen constructor.
        /// </summary>
        public AppException(HttpStatusCode statusCode, string message, object? data) : base(message)
        {
            SetData(data);
            StatusCode = statusCode;
        }

        /// <summary>
        /// AppException sınıfı için message ve hata kodu belirtilen constructor.
        /// </summary>
        public AppException(HttpStatusCode statusCode, string message, string? errorCode) : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// AppException sınıfı için message, hata kodu ve data belirtilen constructor.
        /// </summary>
        public AppException(HttpStatusCode statusCode, string message, string? errorCode, object? data) : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            SetData(data);
        }

        /// <summary>
        /// AppException sınıfı için message, hata kodu ve iç hata belirtilen constructor.
        /// </summary>
        public AppException(HttpStatusCode statusCode, string message, string? errorCode = null, Exception? innerException = null) : base(message, innerException)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// AppException sınıfı için message, hata kodu, data ve iç hata belirtilen constructor.
        /// </summary>
        public AppException(HttpStatusCode statusCode, string message, string? errorCode = null, object? data = null, Exception? innerException = null) : base(message, innerException)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            SetData(data);
        }
    }
}
