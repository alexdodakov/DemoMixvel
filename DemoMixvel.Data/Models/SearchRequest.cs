namespace DemoMixvel.Data.Models;
public class SearchRequest
{
    // Mandatory
    // Start point of route, e.g. Moscow 
    public string Origin { get; set; }

    // Mandatory
    // End point of route, e.g. Sochi
    public string Destination { get; set; }

    // Mandatory
    // Start date of route
    public DateTime OriginDateTime { get; set; }

    // Optional
    public SearchFilter? Filters { get; set; }

    public string GenerateCacheKey() =>
        $"SearchFilter_{Origin}_{Destination}_{OriginDateTime:yyyyMMdd}_{Filters?.DestinationDateTime:yyyyMMdd}_{Filters?.MaxPrice}_{Filters?.MinTimeLimit:yyyyMMdd}";
}