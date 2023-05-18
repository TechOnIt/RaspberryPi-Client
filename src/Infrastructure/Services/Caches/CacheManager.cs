using Microsoft.Extensions.Caching.Distributed;

namespace TechOnIt.Infrastructure.Services.Caches;

public class CacheManager : ICacheManager
{
    #region Props & Ctor
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<CacheManager> _logger;

    public CacheManager(IDistributedCache distributedCache,
        ILogger<CacheManager> logger)
    {
        _distributedCache = distributedCache;
        _logger = logger;
    }
    #endregion

    public async Task<bool> SetAsync<TValue>(string key, TValue value, CancellationToken stoppingToken)
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
            await _distributedCache.SetStringAsync(key, serializedValue, stoppingToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error has occured on set cache.", ex);
        }
        return false;
    }

    public async Task<TValue?> GetAsync<TValue>(string key, CancellationToken stoppingToken)
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
            string? cacheString = await _distributedCache.GetStringAsync(key);
            if (string.IsNullOrEmpty(cacheString))
                return default;
            return JsonSerializer.Deserialize<TValue>(cacheString);
        }
        catch (Exception ex)
        {
            _logger.LogError("An error has occured on get cache.", ex);
        }
        return default;
    }
}