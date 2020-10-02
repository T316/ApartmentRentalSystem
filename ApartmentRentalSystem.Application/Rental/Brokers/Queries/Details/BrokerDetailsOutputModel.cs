namespace ApartmentRentalSystem.Application.Brokerships.Brokers.Queries.Details
{
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;
    using AutoMapper;
    using Common;

    public class BrokerDetailsOutputModel : BrokerOutputModel
    {
        public int TotalApartmentAds { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Broker, BrokerDetailsOutputModel>()
                .IncludeBase<Broker, BrokerOutputModel>()
                .ForMember(d => d.TotalApartmentAds, cfg => cfg
                    .MapFrom(d => d.ApartmentAds.Count));
    }
}
