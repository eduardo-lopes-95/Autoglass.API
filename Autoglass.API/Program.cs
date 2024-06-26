using Autoglass.API.Domain.Core.Interfaces.Repositories;
using Autoglass.API.Domain.Core.Interfaces.Services;
using Autoglass.API.Domain.Services.Services;
using Autoglass.API.Infra.Configurations;
using Autoglass.API.Infra.Extensions;
using Autoglass.API.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

//Configurations
services.AddEndpointsApiExplorer();
services.ConfigureDbConfigOptions();
services.ConfigureDbContext();
services.ConfigureDbHealthCheck();
services.ConfigureBaseUrl();
services.ConfigureSwagger();
services.ConfigureAutomapper();
services.AddControllers().AddValidationControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Binding services
services.AddHttpContextAccessor();
services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwaggerCustomize();

app.UseHealthChecks("/status");

app.MapControllers();

app.Run();
