using Autoglass.API.Infra.Configurations;
using Autoglass.API.Infra.Extensions;
using Autoglass.API.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

//Configurations
services.ConfigureDbConfigOptions();
services.ConfigureDbContext();
services.ConfigureDbHealthCheck();
services.ConfigureAutomapper();

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

//Binding services
services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHealthChecks("/status");

app.MapControllers();

app.Run();
