using AutoMapper;
using DemoMixvel.Data.Models;
using DemoMixvel.Provider.Two.Models;

namespace DemoMixvel.Provider.Two.MappingProfiles;
public class ProviderTwoMappingProfile : Profile
{
    public ProviderTwoMappingProfile()
    {
        CreateMap<ProviderTwoSearchRequest, SearchRequest>()
            .ForMember(dest => dest.Origin,
                opt => opt.MapFrom(src => src.Departure))
            .ForMember(dest => dest.Destination,
                opt => opt.MapFrom(src => src.Arrival))
            .ForMember(dest => dest.OriginDateTime,
                opt => opt.MapFrom(src => src.DepartureDate))
            .ForMember(dest => dest.Filters,
                opt => opt.MapFrom(src => new SearchFilter
                {
                    MinTimeLimit = src.MinTimeLimit
                }));

        CreateMap<Route, ProviderTwoRoute>()
            .ForMember(dest => dest.Departure,
                opt => opt.MapFrom(src => new ProviderTwoPoint
                {
                    Point = src.Origin,
                    Date = src.OriginDateTime
                }))
            .ForMember(dest => dest.Arrival,
                opt => opt.MapFrom(src => new ProviderTwoPoint
                {
                    Point = src.Destination,
                    Date = src.DestinationDateTime
                }))
            .ForMember(dest => dest.Price,
                opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.TimeLimit,
                opt => opt.MapFrom(src => src.TimeLimit));

        CreateMap<SearchResponse, ProviderTwoSearchResponse>()
            .ForMember(dest => dest.Routes,
                opt => opt.MapFrom(src => src.Routes));
    }
}