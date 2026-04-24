using Microsoft.Extensions.Caching.Memory;
using Demo.Application.demo.ports.Out;
using Demo.Application.Common;

namespace Demo.Infrastructure.Cache;

public class ProductStatusCache : IProductStatusCache, IScopedDependency
{
    private readonly IMemoryCache _cache;
    private const string CacheKey = "ProductStatuses";

    public ProductStatusCache(IMemoryCache cache)
    {
        _cache = cache;
    }

    public string GetStatusName(int key)
    {
        var statusDict = _cache.GetOrCreate(CacheKey, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            
            return new Dictionary<int, string>
            {
                { 1, "Active" },
                { 0, "Inactive" }
            };
        });
        return statusDict.TryGetValue(key, out var name) ? name : "Unknown";
    }
}