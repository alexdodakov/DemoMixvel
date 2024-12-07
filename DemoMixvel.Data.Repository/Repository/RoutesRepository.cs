using DemoMixvel.Data.Repository.Model;
using DemoMixvel.Database;
using DemoMixvel.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace DemoMixvel.Data.Repository
{
    public class RoutesRepository : IRoutesRepository
    {
        private readonly RouteDbContext _context;

        public RoutesRepository(RouteDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Route>> GetRoutesByFilterAsync(RouteFilter filter, CancellationToken cancellationToken = default)
        {
            return await GetQuery(_context.Routes, filter)
                .AsNoTracking() 
                .ToListAsync(cancellationToken);
        }

        public IEnumerable<Route> GetRoutesByFilterCached(RouteFilter filter, IEnumerable<Route> routes)
        {
            return GetQuery(routes.AsQueryable(), filter)
                .ToList();
        }

        private IQueryable<Route> GetQuery(IQueryable<Route> source, RouteFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            IQueryable<Route> query = source;

            query = query.Where(r =>
                r.Origin == filter.Origin &&
                r.Destination == filter.Destination &&
                r.OriginDateTime.Date == filter.OriginDateTime.Date
            );

            if (filter.DestinationDateTime.HasValue)
            {
                query = query.Where(r => r.DestinationDateTime.Date <= filter.DestinationDateTime.Value.Date);
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(r => r.Price <= filter.MaxPrice.Value);
            }

            if (filter.MinTimeLimit.HasValue)
            {
                query = query.Where(r => r.TimeLimit >= filter.MinTimeLimit.Value);
            }

            query = query.OrderBy(r => r.OriginDateTime);
            return query;
        }


        public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
        {
            return await _context.Database.CanConnectAsync(cancellationToken);
        }
    }
}
