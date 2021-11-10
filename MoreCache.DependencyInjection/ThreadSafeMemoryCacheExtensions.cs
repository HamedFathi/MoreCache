
using Microsoft.Extensions.DependencyInjection;

namespace MoreCache.DependencyInjection
{
    public static class ThreadSafeMemoryCacheExtensions
    {
        public static IServiceCollection AddThreadSafeMemoryCache(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICache, ThreadSafeMemoryCache>();
            return services;
        }
    }
}