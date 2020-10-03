namespace ApartmentRentalSystem.Application.Brokerships.ApartmentAds.Commands.ChangeAvailability
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Common;
    using ApartmentRentalSystem.Application.Common.Contracts;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Common;
    using ApartmentRentalSystem.Application.Rental.Brokers;
    using MediatR;

    public class ChangeAvailabilityCommand : EntityCommand<int>, IRequest<Result>
    {
        public class ChangeAvailabilityCommandHandler : IRequestHandler<ChangeAvailabilityCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IApartmentAdRepository apartmentAdRepository;
            private readonly IBrokerRepository brokerRepository;

            public ChangeAvailabilityCommandHandler(
                ICurrentUser currentUser,
                IApartmentAdRepository apartmentAdRepository,
                IBrokerRepository brokerRepository)
            {
                this.currentUser = currentUser;
                this.apartmentAdRepository = apartmentAdRepository;
                this.brokerRepository = brokerRepository;
            }

            public async Task<Result> Handle(
                ChangeAvailabilityCommand request, 
                CancellationToken cancellationToken)
            {
                var brokerHasApartment = await this.currentUser.BrokerHasApartmentAd(
                    this.brokerRepository,
                    request.Id,
                    cancellationToken);

                if (!brokerHasApartment)
                {
                    return brokerHasApartment;
                }

                var apartmentAd = await this.apartmentAdRepository
                    .Find(request.Id, cancellationToken);

                apartmentAd.ChangeAvailability();

                await this.apartmentAdRepository.Save(apartmentAd, cancellationToken);

                return Result.Success;
            }
        }
    }
}
