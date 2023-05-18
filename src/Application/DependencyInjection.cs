using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechOnIt.Infrastructure;

namespace TechOnIt.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddBoardManagerServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add cache service.
        services.AddCacheService(configuration);
        return services;
    }
}