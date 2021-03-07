using AutoMapper;
using System;
using Homely.Core.Entities;
using Homely.Services.Models;
using System.Collections.Generic;
using Homely.Services.Enums;

namespace Homely.Services.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<HomelyDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class HomelyDtoMapper : Profile
    {
        public HomelyDtoMapper()
        {
            CreateMap<Listing, ListingDetails>()
                .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.StreetNumber + " " + src.Street + ", "+ src.Suburb + " "+ src.State + " "+ src.Postcode))
                .ForMember(dest=> dest.categoryType, opt => opt.MapFrom(src => Enum.GetName(typeof(CategoryTypes),src.CategoryType)) )
                .ForMember(dest => dest.statusType, opt => opt.MapFrom(src => Enum.GetName(typeof(StatusTypes), src.StatusType)));



            CreateMap<IEnumerable<Listing>, ListingModel>()
                .ForMember(dest => dest.items, opt => opt.MapFrom(src => src));
                
        }

        private object MapCategory(int categoryType)
        {
            throw new NotImplementedException();
        }
    }
}

