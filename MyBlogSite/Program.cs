using Autofac.Extensions.DependencyInjection;
using Serilog;
using MyBlogSite.WebFramework.Configurations;
using MyBlogSite.Data.Repository.UnitofWork;
using MyBlogSite.WebFramework.Attributes;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// derlendiği environment'i çekiyoruz
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

// derlendiği environment'a göre configuration oluşturuyoruz
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.
builder.Services.AddControllers();
// Authentication'u ekliyoruz
builder.Services.AddAuthenticationJWT(configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// api versiyonlama config'ini ekliyoruz
builder.Services.AddCustomApiVersioning();
// swagger config'ini ekliyoruz
builder.Services.AddSwagger();
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
builder.Services.AddScoped<IUnitofwork, UnitOfWork>();
builder.Services.AddScoped<TransactionAttribute>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwaggerConfig();
}

app.UseHttpsRedirection();
// Authentication'u ekliyoruz
app.UseAuthenticationJWT();
app.UseAuthorization();
app.UseCorsPolicy();
app.MapControllers();
// Middlewares'leri ekliyoruz
app.AddMiddlewares();

var url = app.Configuration["BASE_URL"];
var port = app.Configuration["PORT"];
var baseUrl = url is not null && port is not null ? $"{url}:{port}" : "http://localhost:5288";
Log.Information($"Base Url: {baseUrl}");
app.Run(baseUrl);

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