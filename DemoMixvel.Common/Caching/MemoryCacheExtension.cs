using Microsoft.Extensions.Caching.Memory;

namespace DemoMixvel.Common.Caching;
public static class MemoryCacheExtension
{
    public static IEnumerable<T> GetAllCachedItems<T>(this IMemoryCache memoryCache)
    {
        if (memoryCache is MemoryCache cache)
        {
            var keys = cache.Keys;
            return keys.Select(key =>
                {
                    if (memoryCache.TryGetValue(key, out var value) && value is List<T> typedList)
                    {
                        return typedList;
                    }
                    return null;
                })
                .Where(list => list != null)
                .SelectMany(list => list!);
        }

        return Enumerable.Empty<T>();
    }
}
