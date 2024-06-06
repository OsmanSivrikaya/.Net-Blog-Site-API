using Autofac;
using Autofac.Extensions.DependencyInjection;
using MyBlogSite.Attributes;
using MyBlogSite.DependencyResolvers.Autofac;
using MyBlogSite.Repository.UnitofWork;
using MyBlogSite.Configurations;

var builder = WebApplication.CreateBuilder(args);

//Autofac'i ekliyoruz
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureContainer<ContainerBuilder>((container) =>
{
    container.RegisterModule(new AutofacBusinessModule());
});

builder.Services.AddPersistenceServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// cors politikasını ekliyoruz
builder.Services.AddCorsPolicy(builder.Configuration);
//auto mapper ekleniyor
builder.Services.AddAutoMapper();

builder.Services.AddScoped<IUnitofwork, UnitOfWork>();
builder.Services.AddScoped<TransactionAttribute>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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
Console.WriteLine($"Uygulama {app.Configuration["ASPNETCORE_ENVIRONMENT"]} ortamında çalıştırıldı.");
var baseUrl = url is not null && port is not null ? $"{url}:{port}" : "http://localhost:5288";
app.Run(baseUrl);
