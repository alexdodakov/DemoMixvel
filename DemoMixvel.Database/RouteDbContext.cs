using DemoMixvel.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace DemoMixvel.Database;
public class RouteDbContext : DbContext
{
    public RouteDbContext(DbContextOptions<RouteDbContext> options)
        : base(options) { }

    public DbSet<Route> Routes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");
        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(r => r.Id);

            entity.HasIndex(r => new { r.Origin, r.Destination, r.OriginDateTime });

            entity.HasCheckConstraint(
                "CK_Route_Dates",
                "[OriginDateTime] < [DestinationDateTime]"
            );

            entity.HasCheckConstraint(
                "CK_Route_Price",
                "[Price] > 0"
            );
        });

        base.OnModelCreating(modelBuilder);
    }
}