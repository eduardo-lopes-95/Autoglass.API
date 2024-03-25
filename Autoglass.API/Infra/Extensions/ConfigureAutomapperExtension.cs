namespace Autoglass.API.Infra.Extensions;

public static class ConfigureAutomapperExtension
{
    public static void ConfigureAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
