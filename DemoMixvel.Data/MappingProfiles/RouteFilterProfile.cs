using AutoMapper;
using DemoMixvel.Data.Models;
using DemoMixvel.Data.Repository.Model;

namespace DemoMixvel.Data.MappingProfiles
{
    public class RouteFilterProfile: Profile
    {
        public RouteFilterProfile()
        {
            CreateMap<SearchRequest, RouteFilter>()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src.Origin))
                .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.Destination))
                .ForMember(dest => dest.OriginDateTime, opt => opt.MapFrom(src => src.OriginDateTime))
                .ForMember(dest => dest.DestinationDateTime,
                    opt => opt.MapFrom(src => src.Filters != null ? src.Filters.DestinationDateTime : null))
                .ForMember(dest => dest.MaxPrice,
                    opt => opt.MapFrom(src => src.Filters != null ? src.Filters.MaxPrice : null))
                .ForMember(dest => dest.MinTimeLimit,
                    opt => opt.MapFrom(src => src.Filters != null ? src.Filters.MinTimeLimit : null));

            CreateMap<Database.Entity.Route, Route>();
        }
    }
}
