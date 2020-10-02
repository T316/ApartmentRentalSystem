namespace ApartmentRentalSystem.Application.Brokerships.Brokers.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Rental.Brokers;
    using MediatR;

    public class BrokerDetailsQuery : IRequest<BrokerDetailsOutputModel>
    {
        public int Id { get; set; }

        public class BrokerDetailsQueryHandler : IRequestHandler<BrokerDetailsQuery, BrokerDetailsOutputModel>
        {
            private readonly IBrokerRepository brokerRepository;

            public BrokerDetailsQueryHandler(IBrokerRepository brokerRepository) 
                => this.brokerRepository = brokerRepository;

            public async Task<BrokerDetailsOutputModel> Handle(
                BrokerDetailsQuery request,
                CancellationToken cancellationToken)
                => await this.brokerRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
