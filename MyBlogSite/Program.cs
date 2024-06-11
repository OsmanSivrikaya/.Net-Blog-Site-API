using Autofac.Extensions.DependencyInjection;
using Serilog;
using MyBlogSite.WebFramework.Configurations;
using MyBlogSite.Data.Repository.UnitofWork;
using MyBlogSite.WebFramework.Attributes;

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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// api versiyonlama config'ini ekliyoruz
builder.Services.AddCustomApiVersioning();
builder.Services.AddSwaggerGen();
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
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUnitofwork, UnitOfWork>();
builder.Services.AddScoped<TransactionAttribute>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
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
