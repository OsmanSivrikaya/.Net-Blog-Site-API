using Base.Attributes;
using FluentValidation;
using MyBlogSite.Core.Producers;
using MyBlogSite.Core.Producers.Interface;
using MyBlogSite.Dal.Repository.UnitofWork;

namespace Base.Configurations
{
    public static class FluentValidationConfig
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            // Validatörlerinizi burada belirtebilirsiniz
            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddScoped<IUnitofwork, UnitOfWork>();
            services.AddScoped<IEmailProducer, EmailProducer>();
            services.AddScoped<INotificationProducer, NotificationProducer>();
            services.AddScoped<TransactionAttribute>();
            return services;
        }
    }
}