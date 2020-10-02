namespace ApartmentRentalSystem.Application.Brokerships.Brokers.Queries.Common
{
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;
    using Application.Common.Mapping;
    using AutoMapper;

    public class BrokerOutputModel : IMapFrom<Broker>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string PhoneNumber { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Broker, BrokerOutputModel>()
                .ForMember(d => d.PhoneNumber, cfg => cfg
                    .MapFrom(d => d.PhoneNumber.Number));
    }
}
