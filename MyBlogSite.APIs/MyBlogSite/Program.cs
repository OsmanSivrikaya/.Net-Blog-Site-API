using System.Reflection;
using Base.Configurations;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using MyBlogSite.Core.Helpers;
using MyBlogSite.Dal;

var builder = WebApplication.CreateBuilder(args);

// derlendiği environment'i çekiyoruz
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

// derlendiği environment'a göre configuration oluşturuyoruz
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSettings(configuration);
// file storage manager DI yapılandırması
builder.Services.AddFileStoreageSettings(configuration);
builder.Services.AddRabbitMassTransit(configuration);
// Authentication'u ekliyoruz
builder.Services.AddAuthenticationJWT(configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// api versiyonlama config'ini ekliyoruz
builder.Services.AddCustomApiVersioning();

// swagger config'ini ekliyoruz
// XML yorum dosyasını yükler. Bu dosya, API belgeleri için yorumları içerir.
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddSwagger(xmlPath);

// context config'ini ekiyoruz
builder.Services.AddPersistenceServices(configuration);
// serilog ekliyoruz
builder.Services.AddSerilogConfig(configuration);
// cors politikasını ekliyoruz
builder.Services.AddCorsPolicy(configuration);
// autofac'i ekliyoruz
builder.Host.AddAutofac();
// auto mapper ekleniyor
builder.Services.AddAutoMapper();
// fluent validation ekliyoruz
builder.Services.AddFluentValidation();
builder.Services.AddHttpContextAccessor();
ClaimHelper.Configure(builder.Services.BuildServiceProvider().GetRequiredService<IHttpContextAccessor>());

var app = builder.Build();

// Migration'ları otomatik olarak uygula
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ContextDb>();
    await context.Database.MigrateAsync();  // Veritabanını günceller
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwaggerConfig();
//}
//app.UseHttpsRedirection();
// Authentication'u ekliyoruz
app.UseAuthenticationJWT();
app.UseAuthorization();
app.UseCorsPolicy();
app.MapControllers();
// Middlewares'leri ekliyoruz
app.AddMiddlewares();

app.Run();

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, new OpenApiInfo
            {
                Title = $"My API {description.ApiVersion}",
                Version = description.ApiVersion.ToString()
            });
        }
    }
}