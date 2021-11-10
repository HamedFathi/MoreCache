using Microsoft.Extensions.Caching.Memory;
using System;
using System.Runtime.Caching;

namespace MoreCache
{
    public static class MemoryCacheExtensions
    {
        public static TValue AddOrGet<TValue>(this MemoryCache cache, string key, TValue value)
        {
            object item = cache.AddOrGetExisting(key, value, new CacheItemPolicy()) ?? value;

            return (TValue)item;
        }

        public static TValue AddOrGet<TValue>(this MemoryCache cache, string key, Func<string, TValue> valueFactory)
        {
            var lazy = new Lazy<TValue>(() => valueFactory(key));

            Lazy<TValue> item = (Lazy<TValue>)cache.AddOrGetExisting(key, lazy, new CacheItemPolicy()) ?? lazy;

            return item.Value;
        }

        public static TValue AddOrGet<TValue>(this MemoryCache cache, string key, Func<string, TValue> valueFactory, CacheItemPolicy policy, string regionName = null)
        {
            var lazy = new Lazy<TValue>(() => valueFactory(key));

            Lazy<TValue> item = (Lazy<TValue>)cache.AddOrGetExisting(key, lazy, policy, regionName) ?? lazy;

            return item.Value;
        }

        public static TValue AddOrGet<TValue>(this MemoryCache cache, string key, Func<string, TValue> valueFactory, DateTimeOffset absoluteExpiration, string regionName = null)
        {
            var lazy = new Lazy<TValue>(() => valueFactory(key));

            Lazy<TValue> item = (Lazy<TValue>)cache.AddOrGetExisting(key, lazy, absoluteExpiration, regionName) ?? lazy;

            return item.Value;
        }

        public static TValue GetOrAdd<TKey, TValue>(this ObjectCache @this, TKey key, Func<TKey, TValue> valueFactory, CacheItemPolicy policy)
        {
            var lazy = new Lazy<TValue>(() => valueFactory(key), true);
            return ((Lazy<TValue>)@this.AddOrGetExisting(key.ToString(), lazy, policy) ?? lazy).Value;
        }

        public static TReturn SafeGet<TReturn>(this MemoryCache memoryCache, string key, Func<TReturn> objectToCache)
        {
            if (memoryCache.Contains(key))
                return (TReturn)memoryCache[key];

            return (TReturn)(memoryCache[key] = objectToCache());
        }

        public static TReturn SafeGet<TReturn>(this MemoryCache memoryCache, string key, TReturn objectToCache)
        {
            if (memoryCache.Contains(key))
                return (TReturn)memoryCache[key];

            return (TReturn)(memoryCache[key] = objectToCache);
        }

        public static object SafeGet(this MemoryCache memoryCache, string key, Func<object> objectToCache)
        {
            if (memoryCache.Contains(key))
                return memoryCache[key];

            return memoryCache[key] = objectToCache();
        }

        public static object SafeGet(this MemoryCache memoryCache, string key, object objectToCache)
        {
            if (memoryCache.Contains(key))
                return memoryCache[key];

            return memoryCache[key] = objectToCache;
        }

        public static TReturn SafeGet<TReturn>(this IMemoryCache memoryCache, string key, Func<TReturn> objectToCache)
        {
            if (memoryCache.TryGetValue(key, out TReturn cached))
            {
                return cached;
            }
            else
            {
                TReturn data = objectToCache();
                memoryCache.Set(key, data);
                return data;
            }
        }

        public static TReturn SafeGet<TReturn>(this IMemoryCache memoryCache, string key, TReturn objectToCache)
        {
            if (memoryCache.TryGetValue(key, out TReturn cached))
            {
                return cached;
            }
            else
            {
                memoryCache.Set(key, objectToCache);
                return objectToCache;
            }
        }

        public static object SafeGet(this IMemoryCache memoryCache, string key, Func<object> objectToCache)
        {

            if (memoryCache.TryGetValue(key, out var cached))
            {
                return cached;
            }
            else
            {
                var data = objectToCache();
                memoryCache.Set(key, data);
                return data;
            }

        }

        public static object SafeGet(this IMemoryCache memoryCache, string key, object objectToCache)
        {
            if (memoryCache.TryGetValue(key, out var cached))
            {
                return cached;
            }
            else
            {
                memoryCache.Set(key, objectToCache);
                return objectToCache;
            }
        }
    }
}
