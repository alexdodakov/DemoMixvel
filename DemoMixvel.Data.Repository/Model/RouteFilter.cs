﻿namespace DemoMixvel.Data.Repository.Model;
public class RouteFilter
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
    // End date of route
    public DateTime? DestinationDateTime { get; set; }

    // Optional
    // Maximum price of route
    public decimal? MaxPrice { get; set; }

    // Optional
    // Minimum value of timelimit for route
    public DateTime? MinTimeLimit { get; set; }
}