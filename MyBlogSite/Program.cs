using Autofac;
using Autofac.Extensions.DependencyInjection;
using MyBlogSite.Context;
using MyBlogSite.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);

//Autofac'i ekliyoruz
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureContainer<ContainerBuilder>((container) => {
    container.RegisterModule(new AutofacBusinessModule());
});

builder.Services.AddPersistenceServices();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.UseServiceProviderFactory()

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
