using System;
namespace MoreCache
{
    public interface ICache
    {
        T GetOrAdd<T>(string cacheKey, Func<T> factory, DateTimeOffset absoluteExpiration, int size = 1);
        T GetValue<T>(string cacheKey);
        bool TryGetValue<T>(string cacheKey, out T result);
        void Add<T>(string cacheKey, T value, DateTimeOffset absoluteExpiration, int size = 1);
        void Add<T>(string cacheKey, Func<T> factory, DateTimeOffset absoluteExpiration, int size = 1);
        void Add<T>(string cacheKey, T value, int size = 1);
        void Remove(string cacheKey);
    }
}