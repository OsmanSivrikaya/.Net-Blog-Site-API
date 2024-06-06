using Autofac.Extensions.DependencyInjection;
using MyBlogSite.Attributes;
using MyBlogSite.Repository.UnitofWork;
using MyBlogSite.Configurations;

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
builder.Services.AddSwaggerGen();
// autofac'i ekliyoruz
builder.Host.AddAutofac();
// serilog ekliyoruz
builder.Services.AddSerilogConfig(configuration);
// context configini ekiyoruz
builder.Services.AddPersistenceServices(configuration);
// cors politikasını ekliyoruz
builder.Services.AddCorsPolicy(configuration);
// auto mapper ekleniyor
builder.Services.AddAutoMapper();

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
app.AddCorsPolicy();
app.UseAuthorization();
app.MapControllers();

var url = app.Configuration["BASE_URL"];
var port = app.Configuration["PORT"];
var baseUrl = url is not null && port is not null ? $"{url}:{port}" : "http://localhost:5288";
app.Run(baseUrl);
