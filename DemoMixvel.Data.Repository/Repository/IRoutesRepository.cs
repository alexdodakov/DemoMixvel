using DemoMixvel.Data.Repository.Model;
using DemoMixvel.Database.Entity;

namespace DemoMixvel.Data.Repository;
public interface IRoutesRepository
{
    Task<IEnumerable<Route>> GetRoutesByFilterAsync(RouteFilter filter, CancellationToken cancellationToken = default);
    IEnumerable<Route> GetRoutesByFilterCached(RouteFilter filter, IEnumerable<Route> routes);
    Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
}