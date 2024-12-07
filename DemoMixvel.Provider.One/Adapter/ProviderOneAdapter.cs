using AutoMapper;
using DemoMixvel.Data.Models;
using DemoMixvel.Data.Services;
using DemoMixvel.Provider.One.Models;

namespace DemoMixvel.Provider.One.Adapter;
public class ProviderOneAdapter : IProviderOneAdapter
{
    private readonly ISearchService _searchService;
    private readonly IMapper _mapper;

    public ProviderOneAdapter(
        ISearchService searchService,
        IMapper mapper)
    {
        _searchService = searchService;
        _mapper = mapper;
    }

    public async Task<ProviderOneSearchResponse> SearchAsync(
        ProviderOneSearchRequest request,
        CancellationToken cancellationToken)
    {
        var searchRequest = _mapper.Map<SearchRequest>(request);

        var searchResponse = await _searchService.SearchAsync(searchRequest, cancellationToken);

        var providerResponse = _mapper.Map<ProviderOneSearchResponse>(searchResponse);

        return providerResponse;
    }

    public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
    {
        //check accessibility of DB
        return await _searchService.IsAvailableAsync(cancellationToken);
    }
}