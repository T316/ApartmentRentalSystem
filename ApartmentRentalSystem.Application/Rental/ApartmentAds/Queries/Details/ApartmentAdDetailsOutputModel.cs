namespace ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Details
{
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Common;
    using ApartmentRentalSystem.Domain.Common.Models;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using AutoMapper;

    public class ApartmentAdDetailsOutputModel : ApartmentAdOutputModel
    {
        public bool HasParking { get; private set; }

        public bool HasBasement { get; private set; }

        public string HeatingType { get; private set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<ApartmentAd, ApartmentAdDetailsOutputModel>()
                .IncludeBase<ApartmentAd, ApartmentAdOutputModel>()
                .ForMember(c => c.HasParking, cfg => cfg
                    .MapFrom(c => c.Options.HasParking))
                .ForMember(c => c.HasBasement, cfg => cfg
                    .MapFrom(c => c.Options.HasBasement))
                .ForMember(c => c.HeatingType, cfg => cfg
                    .MapFrom(c => Enumeration.NameFromValue<HeatingType>(
                        c.Options.HeatingType.Value)));
    }
}
