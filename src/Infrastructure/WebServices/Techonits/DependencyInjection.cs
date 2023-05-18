using Microsoft.Extensions.DependencyInjection;
using TechOnIt.Infrastructure.WebServices.Techonits.Authentications;
using TechOnIt.Infrastructure.WebServices.Techonits.Devices;

namespace TechOnIt.Infrastructure.WebServices.Techonits;

public static class DependencyInjection
{
    public static IServiceCollection AddTechonitWebService(this IServiceCollection services)
    {
        services.AddTransient<ITechonitWebService, TechonitWebService>();
        services.AddTransient<IAuthTechonitWebService, AuthTechonitWebService>();
        services.AddTransient<IDeviceTechonitWebService, DeviceTechonitWebService>();

        return services;
    }
}