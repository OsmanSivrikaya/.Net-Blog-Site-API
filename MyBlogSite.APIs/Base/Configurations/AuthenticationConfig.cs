using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Base.Configurations
{
    /// <summary>
    /// Kimlik doğrulama yapılandırmasını sağlayan yardımcı sınıf.
    /// </summary>
    public static class AuthenticationConfig
    {
        /// <summary>
        /// JWT tabanlı kimlik doğrulamayı servislere ekler.
        /// </summary>
        /// <param name="services">IServiceCollection nesnesi</param>
        /// <param name="configuration">IConfiguration nesnesi</param>
        /// <returns>IServiceCollection nesnesi</returns>
        public static IServiceCollection AddAuthenticationJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["AppSettings:ValidIssuer"],
                    ValidAudience = configuration["AppSettings:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Secret"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false, // Token süresinin kontrol edilmemesini sağlar
                    ValidateIssuerSigningKey = true
                };
            });

            // Yetkilendirme eklemek için gerekli
            services.AddAuthorization();

            return services;
        }

        /// <summary>
        /// Kimlik doğrulama ve yetkilendirme middleware'lerini kullanmaya başlar.
        /// </summary>
        /// <param name="app">IApplicationBuilder nesnesi</param>
        /// <returns>IApplicationBuilder nesnesi</returns>
        public static IApplicationBuilder UseAuthenticationJWT(this IApplicationBuilder app)
        {
            // Kimlik doğrulama middleware'ini kullanmaya başlar
            app.UseAuthentication();

            // Yetkilendirme middleware'ini kullanmaya başlar
            app.UseAuthorization();

            return app;
        }
    }
}
