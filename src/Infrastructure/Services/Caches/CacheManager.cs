using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace TechOnIt.Infrastructure.Services.Caches;

public class CacheManager : ICacheManager
{
    #region Props & Ctor
    private readonly ILogger<CacheManager> _logger;
    private readonly IMemoryCache _memoryCache;
    public CacheManager(IMemoryCache memoryCache,
        ILogger<CacheManager> logger)
    {
        _memoryCache = memoryCache;
        _logger = logger;
    }
    #endregion

    public bool Set<TValue>(string key, TValue value, DateTimeOffset expirationTime)
    {
        // Validate key.
        if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
        {
            _logger.LogError("Cache key is null on set.");
            throw new ArgumentNullException("Cache key cannot be empty or white space.");
        }
        try
        {
            // Serialize value to string.
            string serializedValue = JsonSerializer.Serialize(value);
            // Store serialized value object.
            _memoryCache.Set(key, serializedValue, expirationTime);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error has occured on set cache.", ex);
        }
        return false;
    }

    public TValue? Get<TValue>(string key)
    {
        // Validate key.
        if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
        {
            _logger.LogError("Cache key is null on set.");
            throw new ArgumentNullException("Cache key cannot be empty or white space.");
        }
        try
        {
            // Find cache instance by key.
            return _memoryCache.Get<TValue>(key);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error has occured on get cache.", ex);
        }
        return default;
    }
}