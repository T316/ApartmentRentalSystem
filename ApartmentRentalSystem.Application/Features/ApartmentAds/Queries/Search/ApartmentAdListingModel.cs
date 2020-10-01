using ApartmentRentalSystem.Application.Mapping;
using ApartmentRentalSystem.Domain.Models.ApartmentAds;
using AutoMapper;

namespace ApartmentRentalSystem.Application.Features.ApartmentAds.Queries.Search
{
    public class ApartmentAdListingModel : IMapFrom<ApartmentAd>
    {
        public int Id { get; private set; }

        public string Neighborhood { get; private set; } = default!;

        public int Floor { get; private set; }

        public string ImageUrl { get; private set; } = default!;

        public string Category { get; private set; } = default!;

        public decimal PricePerMonth { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<ApartmentAd, ApartmentAdListingModel>()
                .ForMember(ad => ad.Neighborhood, cfg => cfg
                    .MapFrom(ad => ad.Neighborhood.Name))
                .ForMember(ad => ad.Category, cfg => cfg
                    .MapFrom(ad => ad.Category.Name));
    }
}
