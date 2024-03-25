using Autoglass.API.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Autoglass.API.Infra.Configurations;

public static class ConfigureDbContextExtension
{
    public static void ConfigureDbContext(this IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();
        var options = serviceProvider.GetRequiredService<IOptionsMonitor<DbConectionOption>>();
        services.AddDbContextPool<AutoglassContext>(opt => opt.UseSqlServer(options.CurrentValue.AutoglassConnection));

        EnsureCreateDatabase(services);
    }

    private static void EnsureCreateDatabase(IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();
        var context = serviceProvider.GetRequiredService<AutoglassContext>();
        context.Database.EnsureCreated();
    }
}
