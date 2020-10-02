namespace ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Common;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds;
    using ApartmentRentalSystem.Application.Rental.Brokers;
    using MediatR;

    public class ApartmentAdDetailsQuery : EntityCommand<int>, IRequest<ApartmentAdDetailsOutputModel>
    {
        public class ApartmentAdDetailsQueryHandler : IRequestHandler<ApartmentAdDetailsQuery, ApartmentAdDetailsOutputModel>
        {
            private readonly IApartmentAdRepository apartmentAdRepository;
            private readonly IBrokerRepository brokerRepository;

            public ApartmentAdDetailsQueryHandler(
                IApartmentAdRepository apartmentAdRepository,
                IBrokerRepository brokerRepository)
            {
                this.apartmentAdRepository = apartmentAdRepository;
                this.brokerRepository = brokerRepository;
            }

            public async Task<ApartmentAdDetailsOutputModel> Handle(
                ApartmentAdDetailsQuery request,
                CancellationToken cancellationToken)
            {
                var apartmentAdDetails = await this.apartmentAdRepository.GetDetails(
                    request.Id,
                    cancellationToken);

                return apartmentAdDetails;
            }
        }
    }
}
