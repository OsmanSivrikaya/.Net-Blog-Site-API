using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Dal.Repository.UnitofWork;
using Serilog;

namespace Base.Attributes
{
    /// <summary>
    /// TransactionAttribute sınıfı, method'da bir hata durumda yapılan sql işlemlerinde rollback yapar.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// TransactionAttribute sınıfının yapıcı metodu.
        /// </summary>
        public TransactionAttribute() : base(typeof(TransactionFilter))
        {
        }

        private class TransactionFilter : IAsyncActionFilter
        {
            private readonly IUnitofwork _unitOfWork;
            private bool _transactionStarted = false;

            /// <summary>
            /// TransactionFilter sınıfının yapıcı metodu.
            /// </summary>
            /// <param name="unitOfWork">UnitOfWork nesnesi.</param>
            public TransactionFilter(IUnitofwork unitOfWork)
            {
                _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            }

            /// <summary>
            /// Bir HTTP isteği yapıldığında çalıştırılır.
            /// </summary>
            /// <param name="context">Aksiyonun çalıştırıldığı bağlam.</param>
            /// <param name="next">Sonraki aksiyon adımı.</param>
            /// <returns></returns>
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                try
                {
                    // Transaction başlatma
                    if (!_transactionStarted)
                    {
                        await _unitOfWork.BeginTransactionAsync();
                        _transactionStarted = true;
                    }

                    var resultContext = await next();

                    // Eğer bir hata varsa ve henüz işlenmemişse
                    if (resultContext.Exception != null && !resultContext.ExceptionHandled)
                    {
                        // Transaction'ı geri alma
                        await _unitOfWork.RollbackAsync();

                        // Hata işleme
                        HandleException(resultContext);

                        // Hata işlendi olarak işaretleme
                        resultContext.ExceptionHandled = true;
                    }
                    else
                    {
                        // Hata yoksa veya işlenmişse, Transaction'ı tamamlama
                        await _unitOfWork.CommitAsync();
                    }
                }
                finally
                {
                    // Kaynakları temizleme
                    if (_transactionStarted)
                    {
                        _unitOfWork.Dispose();
                    }
                }
            }

            // TODO : Yapılan exception middleware'a yönlendir
            /// <summary>
            /// Bir hata durumunda işlenmemiş bir hata oluşturur.
            /// </summary>
            /// <param name="context">Aksiyonun çalıştırıldığı bağlam.</param>
            private void HandleException(ActionExecutedContext context)
            {
                var exception = context.Exception;

                // hata durumunda serilog ile db'ye kayıt ediyor
                Log.Warning(exception, "Transaction Filter Error");
                
                // Hata bilgilerini ResponseDto formatında oluştur
                var response = Result.BadRequest(exception?.Message, null, null, exception?.StackTrace);

                // Hata bilgilerini IActionResult formatına dönüştür
                context.Result = new JsonResult(response)
                {
                    StatusCode = response.StatusCode
                };
            }
        }
    }
}
