using Autoglass.API.Domain.Core.Interfaces.Services;
using Autoglass.API.Domain.Services.Services;

namespace Autoglass.API.Infra.Configurations;

public static class ConfigureBaseUrlExtension
{
    public static void ConfigureBaseUrl(this IServiceCollection services)
    {
        services.AddSingleton<IUriService>(o =>
        {
            var accessor = o.GetRequiredService<IHttpContextAccessor>();
            var request = accessor.HttpContext.Request;
            var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
            return new UriService(uri);
        });
    }
}
