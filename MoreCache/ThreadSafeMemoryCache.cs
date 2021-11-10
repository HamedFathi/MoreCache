using Microsoft.Extensions.Caching.Memory;
using System;

namespace MoreCache
{
    public class ThreadSafeMemoryCache : ICache
    {
        private static class TypeLock<T>
        {
            public static object Lock { get; } = new object();
        }

        private readonly IMemoryCache _memoryCache;

        public ThreadSafeMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public void Add<T>(string cacheKey, Func<T> factory, DateTimeOffset absoluteExpiration, int size = 1)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            _memoryCache.Set(cacheKey, factory(), new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = absoluteExpiration,
            });
        }

        public void Add<T>(string cacheKey, T value, DateTimeOffset absoluteExpiration, int size = 1)
        {
            _memoryCache.Set(cacheKey, value, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = absoluteExpiration,
            });
        }

        public void Add<T>(string cacheKey, T value, int size = 1)
        {
            _memoryCache.Set(cacheKey, value, new MemoryCacheEntryOptions());
        }

        public T GetOrAdd<T>(string cacheKey, Func<T> factory, DateTimeOffset absoluteExpiration, int size = 1)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            if (_memoryCache.TryGetValue<T>(cacheKey, out var result))
            {
                return result;
            }
            lock (TypeLock<T>.Lock)
            {
                if (_memoryCache.TryGetValue(cacheKey, out result))
                {
                    return result;
                }
                result = factory();
                _memoryCache.Set(cacheKey, result, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = absoluteExpiration,
                });
                return result;
            }
        }

        public T GetValue<T>(string cacheKey)
        {
            return _memoryCache.Get<T>(cacheKey);
        }

        public void Remove(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }

        public bool TryGetValue<T>(string cacheKey, out T result)
        {
            return _memoryCache.TryGetValue(cacheKey, out result);
        }
    }
}
