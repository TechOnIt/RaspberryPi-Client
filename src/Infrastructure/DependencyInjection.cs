using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechOnIt.Infrastructure.Services.Caches;

namespace TechOnIt.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCacheService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICacheManager, CacheManager>();

        services.AddStackExchangeRedisCache(options =>
        {
            options.InstanceName = "Techonit";
            options.Configuration = configuration.GetConnectionString("Redis");
        });

        return services;
    }
}