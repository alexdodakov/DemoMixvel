using AutoMapper;
using DemoMixvel.Data.Models;
using DemoMixvel.Data.Services;
using DemoMixvel.Provider.Two.Models;

namespace DemoMixvel.Provider.Two.Adapter;
public class ProviderTwoAdapter : IProviderTwoAdapter
{
    private readonly ISearchService _searchService;
    private readonly IMapper _mapper;

    public ProviderTwoAdapter(
        ISearchService searchService,
        IMapper mapper)
    {
        _searchService = searchService;
        _mapper = mapper;
    }

    public async Task<ProviderTwoSearchResponse> SearchAsync(
        ProviderTwoSearchRequest request,
        CancellationToken cancellationToken)
    {
        var searchRequest = _mapper.Map<SearchRequest>(request);
        
        var searchResponse = await _searchService.SearchAsync(searchRequest, cancellationToken);

        var providerResponse = _mapper.Map<ProviderTwoSearchResponse>(searchResponse);

        return providerResponse;
    }

    public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
    {
        //simulate random accesibility
        var randomResult = new Random().Next(0, 8) < 3;
        return await Task.FromResult(randomResult);
    }
}