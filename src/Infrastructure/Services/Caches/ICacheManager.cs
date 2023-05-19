namespace TechOnIt.Infrastructure.Services.Caches;

public interface ICacheManager
{
    /// <summary>
    /// Store object to cache.
    /// </summary>
    /// <typeparam name="TValue">Type of object for cache.</typeparam>
    /// <param name="key">Key of cache instance.</param>
    /// <param name="value">Object model value for cache.</param>
    public bool Set<TValue>(string key, TValue value, DateTimeOffset expirationTime);
    /// <summary>
    /// Read object from cache.
    /// </summary>
    /// <typeparam name="TValue">Type of cached object.</typeparam>
    /// <param name="key">Instance key.</param>
    public TValue? Get<TValue>(string key);
}