using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlogSite.Context;
using MyBlogSite.Repository.UnitofWork;

namespace MyBlogSite.Attributes
{
    // Bu attribute, bir metot çağrıldığında otomatik olarak transaction yönetimini sağlar.
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TransactionAttribute : Attribute, IAsyncActionFilter
    {
        // Metot çağrıldığında bu metot çalışır.
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Unit of Work, dependency injection ile alınır.
            var unitOfWork = (IUnitofwork)context.HttpContext.RequestServices.GetService(typeof(IUnitofwork));

            try
            {
                // Metot çağrısını gerçekleştirir.
                var resultContext = await next();

                // Eğer bir hata olmazsa veya hata işlenirse, işlemi commit et.
                if (resultContext.Exception == null || resultContext.ExceptionHandled)
                    await unitOfWork.CommitAsync(true);
                else
                    await unitOfWork.CommitAsync(false);
            }
            catch
            {
                // Hata olması durumunda işlemi rollback et.
                await unitOfWork.CommitAsync(false);

                // 500 hata kodu ile bir hata mesajı döndür.
                context.Result = new ObjectResult("İşlem sırasında bir hata oluştu.")
                {
                    StatusCode = 500
                };
                return;
            }
        }
    }
}
