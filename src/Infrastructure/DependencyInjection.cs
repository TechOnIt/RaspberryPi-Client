using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using TechOnIt.Infrastructure.Services.Caches;
using TechOnIt.Infrastructure.WebServices.Techonits;
using TechOnIt.Infrastructure.WebServices.Techonits.Authentications;
using TechOnIt.Infrastructure.WebServices.Techonits.Devices;

namespace TechOnIt.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Register cache manager service & redis stack exchange.
    /// </summary>
    public static IServiceCollection AddCacheService(this IServiceCollection services, IConfiguration configuration)
    {
        // Register cache manager service.
        services.AddSingleton<IMemoryCache, MemoryCache>();
        services.AddSingleton<ICacheManager, CacheManager>();
        //// Register redis as cache.
        //services.AddStackExchangeRedisCache(options =>
        //{
        //    options.InstanceName = "Techonit";
        //    options.Configuration = configuration.GetConnectionString("Redis");
        //});
        return services;
    }

    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {

        services.AddSingleton<ITechonitWebService, TechonitWebService>();
        services.AddSingleton<IAuthTechonitWebService, AuthTechonitWebService>();
        services.AddSingleton<IDeviceTechonitWebService, DeviceTechonitWebService>();

        return services;
    }
}