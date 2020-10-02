namespace ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Common
{
    using ApartmentRentalSystem.Application.Common.Mapping;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using AutoMapper;

    public class ApartmentAdOutputModel : IMapFrom<ApartmentAd>
    {
        public int Id { get; private set; }

        public string Neighborhood { get; private set; } = default!;

        public int Floor { get; private set; }

        public string ImageUrl { get; private set; } = default!;

        public string Category { get; private set; } = default!;

        public decimal PricePerMonth { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<ApartmentAd, ApartmentAdOutputModel>()
                .ForMember(ad => ad.Neighborhood, cfg => cfg
                    .MapFrom(ad => ad.Neighborhood.Name))
                .ForMember(ad => ad.Category, cfg => cfg
                    .MapFrom(ad => ad.Category.Name));
    }
}
