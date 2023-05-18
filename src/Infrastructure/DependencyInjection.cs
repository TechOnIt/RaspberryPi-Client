using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechOnIt.Infrastructure.Services.Caches;

namespace TechOnIt.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Register cache manager service & redis stack exchange.
    /// </summary>
    public static IServiceCollection AddCacheService(this IServiceCollection services, IConfiguration configuration)
    {
        // Register cache manager service.
        services.AddScoped<ICacheManager, CacheManager>();
        // Register redis as cache.
        services.AddStackExchangeRedisCache(options =>
        {
            options.InstanceName = "Techonit";
            options.Configuration = configuration.GetConnectionString("Redis");
        });
        return services;
    }
}