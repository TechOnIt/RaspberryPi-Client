using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechOnIt.Application.Services;
using TechOnIt.Infrastructure;

namespace TechOnIt.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddBoardManagerServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add cache service.
        services.AddCacheService(configuration);

        // Add web services.
        services.AddWebServices();

        //services.AddScoped<IDeviceManager, DeviceManager>();
        services.AddSingleton<IBoardManager, BoardManager>();
        return services;
    }
}