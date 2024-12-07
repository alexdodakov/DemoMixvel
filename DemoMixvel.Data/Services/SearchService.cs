using AutoMapper;
using DemoMixvel.Common.Caching;
using DemoMixvel.Data.Models;
using DemoMixvel.Data.Repository;
using DemoMixvel.Data.Repository.Model;
using Microsoft.Extensions.Caching.Memory;

namespace DemoMixvel.Data.Services;
public class SearchService : ISearchService
{
    private readonly IRoutesRepository _repository;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;
    private readonly MemoryCacheEntryOptions _memoryCacheEntryOptions;

    public SearchService(
        IRoutesRepository repository,
        IMapper mapper,
        IMemoryCache memoryCache,
        MemoryCacheEntryOptions memoryCacheEntryOptions)
    {
        _repository = repository;
        _mapper = mapper;
        _memoryCache = memoryCache;
        _memoryCacheEntryOptions = memoryCacheEntryOptions;
    }

    public async Task<SearchResponse> SearchAsync(
        SearchRequest request,
        CancellationToken cancellationToken)
    {

        var filter = _mapper.Map<RouteFilter>(request);
        IEnumerable<Database.Entity.Route>? routes = null;
        var cacheKey = request.GenerateCacheKey();

        if (request.Filters?.OnlyCached == true)
        {
            var cachedRoutes = _memoryCache.GetAllCachedItems<Database.Entity.Route>();
            routes = _repository.GetRoutesByFilterCached(filter, cachedRoutes);
        }
        else
        {
            if (!_memoryCache.TryGetValue(cacheKey, out routes))
            {
                routes = await _repository.GetRoutesByFilterAsync(filter, cancellationToken);
                _memoryCache.Set(cacheKey, routes, _memoryCacheEntryOptions);
            }
        }

        if (routes == null || !routes.Any())
        {
            return new SearchResponse
            {
                Routes = Array.Empty<Route>(),
                MinPrice = 0,
                MaxPrice = 0,
                MinMinutesRoute = 0,
                MaxMinutesRoute = 0
            };
        }

        return new SearchResponse
        {
            Routes = _mapper.Map<Route[]>(routes),
            MinPrice = routes.Min(r => r.Price),
            MaxPrice = routes.Max(r => r.Price),
            MinMinutesRoute = routes.Min(r => (int)(r.DestinationDateTime - r.OriginDateTime).TotalMinutes),
            MaxMinutesRoute = routes.Max(r => (int)(r.DestinationDateTime - r.OriginDateTime).TotalMinutes)
        };
    }


    public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
    {
        return await _repository.IsAvailableAsync(cancellationToken);
    }
}