using DemoMixvel.Provider.One.Models;

namespace DemoMixvel.Provider.One.Adapter;
public interface IProviderOneAdapter
{
    Task<ProviderOneSearchResponse> SearchAsync(
        ProviderOneSearchRequest request,
        CancellationToken cancellationToken);

    Task<bool> IsAvailableAsync(
        CancellationToken cancellationToken);
}
