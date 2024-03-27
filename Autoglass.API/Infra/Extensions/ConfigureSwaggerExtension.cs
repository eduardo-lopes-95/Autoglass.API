using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Autoglass.API.Infra.Extensions;

public static class ConfigureSwaggerExtension
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Autoglass API",
                Version = "v1",
                Description = "Autoglass API Services.",
                Contact = new OpenApiContact
                {
                    Name = "Eduardo Sabino"
                },
            });

            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }

    public static void UseSwaggerCustomize(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Autoglass API");
            c.RoutePrefix = string.Empty;
        });
    }
}
