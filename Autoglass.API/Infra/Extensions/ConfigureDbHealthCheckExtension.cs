using Autoglass.API.Infra.Context;

namespace Autoglass.API.Infra.Extensions;

public static class ConfigureDbHealthCheckExtension
{
    public static void ConfigureDbHealthCheck(this IServiceCollection services)
    {
        services.AddHealthChecks().AddDbContextCheck<AutoglassContext>();
    }
}
