using Autoglass.API.Infra.Configurations;

namespace Autoglass.API.Infra.Extensions;

public static class ConfigureDbConfigOptionsExtension
{
    public static void ConfigureDbConfigOptions(this IServiceCollection services)
    {
        services.AddOptions<DbConectionOption>()
                 .BindConfiguration(DbConectionOption.SECTION_KEY)
                 .ValidateDataAnnotations().ValidateOnStart();
    }
}
