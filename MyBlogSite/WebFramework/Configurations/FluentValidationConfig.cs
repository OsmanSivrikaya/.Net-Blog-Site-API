using FluentValidation;
using FluentValidation.AspNetCore;

namespace MyBlogSite.WebFramework.Configurations
{
    public static class FluentValidationConfig
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            // Validatörlerinizi burada belirtebilirsiniz
            services.AddValidatorsFromAssemblyContaining<Program>();
            return services;
        }
    }
}