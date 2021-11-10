using Microsoft.Extensions.Caching.Distributed;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MoreCache
{
    public static class DistributedCacheExtensions
    {
        public static async Task<bool?> GetBooleanAsync(this IDistributedCache cache, string key)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            var bytes = await cache.GetAsync(key).ConfigureAwait(false);
            if (bytes == null)
            {
                return null;
            }
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryReader = new BinaryReader(memoryStream);
                return binaryReader.ReadBoolean();
            }
        }

        public static async Task<char?> GetCharAsync(this IDistributedCache cache, string key)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            var bytes = await cache.GetAsync(key).ConfigureAwait(false);
            if (bytes == null)
            {
                return null;
            }
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryReader = new BinaryReader(memoryStream);
                return binaryReader.ReadChar();
            }
        }

        public static async Task<decimal?> GetDecimalAsync(this IDistributedCache cache, string key)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            var bytes = await cache.GetAsync(key).ConfigureAwait(false);
            if (bytes == null)
            {
                return null;
            }
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryReader = new BinaryReader(memoryStream);
                return binaryReader.ReadDecimal();
            }
        }

        public static async Task<double?> GetDoubleAsync(this IDistributedCache cache, string key)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            var bytes = await cache.GetAsync(key).ConfigureAwait(false);
            if (bytes == null)
            {
                return null;
            }
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryReader = new BinaryReader(memoryStream);
                return binaryReader.ReadDouble();
            }
        }

        public static async Task<float?> GetFloatAsync(this IDistributedCache cache, string key)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            var bytes = await cache.GetAsync(key).ConfigureAwait(false);
            if (bytes == null)
            {
                return null;
            }
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryReader = new BinaryReader(memoryStream);
                return binaryReader.ReadSingle();
            }
        }

        public static async Task<int?> GetIntAsync(this IDistributedCache cache, string key)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            var bytes = await cache.GetAsync(key).ConfigureAwait(false);
            if (bytes == null)
            {
                return null;
            }
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryReader = new BinaryReader(memoryStream);
                return binaryReader.ReadInt32();
            }
        }

        public static async Task<long?> GetLongAsync(this IDistributedCache cache, string key)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            var bytes = await cache.GetAsync(key).ConfigureAwait(false);
            if (bytes == null)
            {
                return null;
            }
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryReader = new BinaryReader(memoryStream);
                return binaryReader.ReadInt64();
            }
        }

        public static async Task<short?> GetShortAsync(this IDistributedCache cache, string key)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            var bytes = await cache.GetAsync(key).ConfigureAwait(false);
            if (bytes == null)
            {
                return null;
            }
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryReader = new BinaryReader(memoryStream);
                return binaryReader.ReadInt16();
            }
        }

        public static async Task<string> GetStringAsync(this IDistributedCache cache, string key, Encoding encoding = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            var bytes = await cache.GetAsync(key).ConfigureAwait(false);
            if (bytes == null)
            {
                return null;
            }
            return encoding.GetString(bytes);
        }

        public static Task SetAsync(
                    this IDistributedCache cache,
                    string key,
                    bool value,
                    DistributedCacheEntryOptions options = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (options == null)
            {
                options = new DistributedCacheEntryOptions();
            }
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                var binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write(value);
                bytes = memoryStream.ToArray();
            }
            return cache.SetAsync(key, bytes, options);
        }

        public static Task SetAsync(
                    this IDistributedCache cache,
                    string key,
                    char value,
                    DistributedCacheEntryOptions options = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (options == null)
            {
                options = new DistributedCacheEntryOptions();
            }
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                var binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write(value);
                bytes = memoryStream.ToArray();
            }
            return cache.SetAsync(key, bytes, options);
        }

        public static Task SetAsync(
                    this IDistributedCache cache,
                    string key,
                    decimal value,
                    DistributedCacheEntryOptions options = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (options == null)
            {
                options = new DistributedCacheEntryOptions();
            }
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                var binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write(value);
                bytes = memoryStream.ToArray();
            }
            return cache.SetAsync(key, bytes, options);
        }

        public static Task SetAsync(
                    this IDistributedCache cache,
                    string key,
                    double value,
                    DistributedCacheEntryOptions options)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (options == null)
            {
                options = new DistributedCacheEntryOptions();
            }
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                var binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write(value);
                bytes = memoryStream.ToArray();
            }
            return cache.SetAsync(key, bytes, options);
        }

        public static Task SetAsync(
                    this IDistributedCache cache,
                    string key,
                    short value,
                    DistributedCacheEntryOptions options = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (options == null)
            {
                options = new DistributedCacheEntryOptions();
            }
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                var binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write(value);
                bytes = memoryStream.ToArray();
            }
            return cache.SetAsync(key, bytes, options);
        }

        public static Task SetAsync(
                    this IDistributedCache cache,
                    string key,
                    int value,
                    DistributedCacheEntryOptions options = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (options == null)
            {
                options = new DistributedCacheEntryOptions();
            }
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                var binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write(value);
                bytes = memoryStream.ToArray();
            }
            return cache.SetAsync(key, bytes, options);
        }

        public static Task SetAsync(
                    this IDistributedCache cache,
                    string key,
                    long value,
                    DistributedCacheEntryOptions options = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (options == null)
            {
                options = new DistributedCacheEntryOptions();
            }
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                var binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write(value);
                bytes = memoryStream.ToArray();
            }
            return cache.SetAsync(key, bytes, options);
        }

        public static Task SetAsync(
                    this IDistributedCache cache,
                    string key,
                    float value,
                    DistributedCacheEntryOptions options = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (options == null)
            {
                options = new DistributedCacheEntryOptions();
            }
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                var binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write(value);
                bytes = memoryStream.ToArray();
            }
            return cache.SetAsync(key, bytes, options);
        }

        public static Task SetAsync(
                    this IDistributedCache cache,
                    string key,
                    string value,
                    DistributedCacheEntryOptions options = null) =>
                    SetAsync(cache, key, value, null, options);

        public static Task SetAsync(
                    this IDistributedCache cache,
                    string key,
                    string value,
                    Encoding encoding = null,
                    DistributedCacheEntryOptions options = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            if (options == null)
            {
                options = new DistributedCacheEntryOptions();
            }
            var bytes = encoding.GetBytes(value);
            return cache.SetAsync(key, bytes, options);
        }
    }
}
