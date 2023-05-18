using Microsoft.Extensions.DependencyInjection;

namespace TechOnIt.Infrastructure.WebServices.Techonits;

public static class DependencyInjection
{
    public static IServiceCollection AddTechonitService(this IServiceCollection services)
    {
        services.AddTransient<ITechonitWebService, TechonitWebService>();
        services.AddTransient<ITechonitAuthWebService, TechonitAuthWebService>();
        services.AddTransient<ITechonitDeviceWebService, TechonitDeviceWebService>();

        return services;
    }
}