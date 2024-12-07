using AutoMapper;
using DemoMixvel.Data.Models;
using DemoMixvel.Provider.One.Models;

namespace DemoMixvel.Provider.One.MappingProfiles;
public class ProviderOneMappingProfile : Profile
{
    public ProviderOneMappingProfile()
    {
        CreateMap<ProviderOneSearchRequest, SearchRequest>()
            .ForMember(dest => dest.Origin,
                opt => opt.MapFrom(src => src.From))
            .ForMember(dest => dest.Destination,
                opt => opt.MapFrom(src => src.To))
            .ForMember(dest => dest.OriginDateTime,
                opt => opt.MapFrom(src => src.DateFrom))
            .ForMember(dest => dest.Filters,
                opt => opt.MapFrom(src => new SearchFilter
                {
                    DestinationDateTime = src.DateTo,
                    MaxPrice = src.MaxPrice
                }));

        CreateMap<SearchResponse, ProviderOneSearchResponse>();

        CreateMap<Route, ProviderOneRoute>()
            .ForMember(dest => dest.From,
                opt => opt.MapFrom(src => src.Origin))
            .ForMember(dest => dest.To,
                opt => opt.MapFrom(src => src.Destination))
            .ForMember(dest => dest.DateFrom,
                opt => opt.MapFrom(src => src.OriginDateTime))
            .ForMember(dest => dest.DateTo,
                opt => opt.MapFrom(src => src.DestinationDateTime));
    }
}