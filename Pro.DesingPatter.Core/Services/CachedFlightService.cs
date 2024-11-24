using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Pro.DesingPatter.Core.Interfaces;
using Pro.DesingPatter.Core.Models;

namespace Pro.DesingPatter.Core.Services;

public class CachedFlightService(IFlightService inner, IMemoryCache cache, ILogger<CachedFlightService> logger) : IFlightService
{
    public List<Flight> GetFlights(string origin, string destination)
    {
        var cacheKey = $"{origin}-{destination}"; if (cache.TryGetValue(cacheKey, out List<Flight>? flights))
        {
            logger.LogInformation("Cache hit for {CacheKey}", cacheKey);
            return flights;
        }

        logger.LogInformation("Cache miss for {CacheKey}", cacheKey);

        flights = inner.GetFlights(origin, destination); cache.Set(cacheKey, flights, TimeSpan.FromMinutes(5));
        return flights;
    }
}
