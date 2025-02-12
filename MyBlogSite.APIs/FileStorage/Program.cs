using System.Reflection;
using Base.Configurations;

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

builder.Services.AddSwagger();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSettings(configuration);
// file storage manager DI yapılandırması
builder.Services.AddFileStoreageSettings(configuration);
// Authentication'u ekliyoruz
builder.Services.AddAuthenticationJWT(configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// api versiyonlama config'ini ekliyoruz
builder.Services.AddCustomApiVersioning();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Authentication'u ekliyoruz
app.UseAuthenticationJWT();
app.UseAuthorization();
app.UseCorsPolicy();
app.MapControllers();
// Middlewares'leri ekliyoruz
app.AddMiddlewares();

app.Run();