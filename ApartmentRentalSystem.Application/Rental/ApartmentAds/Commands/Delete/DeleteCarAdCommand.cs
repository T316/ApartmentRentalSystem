namespace ApartmentRentalSystem.Application.Brokerships.ApartmentAds.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Rental.ApartmentAds;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Common;
    using ApartmentRentalSystem.Application.Rental.Brokers;
    using Application.Common;
    using Application.Common.Contracts;
    using MediatR;

    public class DeleteApartmentAdCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteApartmentAdCommandHandler : IRequestHandler<DeleteApartmentAdCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IApartmentAdRepository apartmentAdRepository;
            private readonly IBrokerRepository brokerRepository;

            public DeleteApartmentAdCommandHandler(
                ICurrentUser currentUser, 
                IApartmentAdRepository apartmentAdRepository, 
                IBrokerRepository brokerRepository)
            {
                this.currentUser = currentUser;
                this.apartmentAdRepository = apartmentAdRepository;
                this.brokerRepository = brokerRepository;
            }

            public async Task<Result> Handle(
                DeleteApartmentAdCommand request, 
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

                return await this.apartmentAdRepository.Delete(
                    request.Id, 
                    cancellationToken);
            }
        }
    }
}
