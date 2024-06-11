using FluentValidation;

namespace MyBlogSite.WebFramework.Configurations
{
    public static class FluentValidationConfig
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            // Validatörlerinizi burada belirtebilirsiniz
            services.AddValidatorsFromAssemblyContaining<Program>();
            return services;
        }
    }
}