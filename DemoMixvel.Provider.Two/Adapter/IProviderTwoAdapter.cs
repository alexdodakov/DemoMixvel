using DemoMixvel.Provider.Two.Models;

namespace DemoMixvel.Provider.Two.Adapter;
public interface IProviderTwoAdapter
{
    Task<ProviderTwoSearchResponse> SearchAsync(
        ProviderTwoSearchRequest request,
        CancellationToken cancellationToken);

    Task<bool> IsAvailableAsync(
            CancellationToken cancellationToken);
}