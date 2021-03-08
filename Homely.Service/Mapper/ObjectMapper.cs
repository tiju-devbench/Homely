using AutoMapper;
using System;
using Homely.Core.Entities;
using Homely.Services.Models;
using System.Collections.Generic;
using Homely.Services.Enums;
using System.Globalization;
using System.Text.RegularExpressions;

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
                .ForMember(dest => dest.statusType, opt => opt.MapFrom(src => Enum.GetName(typeof(StatusTypes), src.StatusType)))
                .ForMember(dest => dest.ShortPrice, opt => opt.MapFrom(src => GetShortPrice(src.DisplayPrice)));



            CreateMap<IEnumerable<Listing>, ListingModel>()
                .ForMember(dest => dest.items, opt => opt.MapFrom(src => src));
                
        }

        private static string GetShortPrice(string displayPrice)
        {
            if (displayPrice.Contains('$'))
            {
                var priceString = SanitizeDisplayPrice(displayPrice.Substring(displayPrice.IndexOf('$')));

                int.TryParse(priceString, NumberStyles.Currency, null, out int n);
                if (n < 1000)
                    return "$" + n.ToString();

                if (n < 10000)
                    return String.Format("${0:#,.##}k", n - 5);

                if (n < 100000)
                    return String.Format("${0:#,.#}k", n - 50);

                if (n < 1000000)
                    return String.Format("${0:#,.}k", n - 500);

                if (n < 10000000)
                    return String.Format("${0:#,,.##}m", n - 5000);

                if (n < 100000000)
                    return String.Format("${0:#,,.#}m", n - 50000);

                if (n < 1000000000)
                    return String.Format("${0:#,,.}m", n - 500000);

                return String.Format("${0:#,,,.##}b", n - 5000000);
            }
            return "NULL";
        }

        private static string SanitizeDisplayPrice(string input)
        {
            Regex r = new Regex(
                 "(?:[^0-9 ]|(?<=['\"])s)",
                RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(input, String.Empty);
        }

    }
}

