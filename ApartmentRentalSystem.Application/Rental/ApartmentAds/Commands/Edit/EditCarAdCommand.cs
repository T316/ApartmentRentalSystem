namespace ApartmentRentalSystem.Application.Brokerships.ApartmentAds.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Rental.ApartmentAds;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Common;
    using ApartmentRentalSystem.Application.Rental.Brokers;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using Application.Common;
    using Application.Common.Contracts;
    using Domain.Common.Models;
    using MediatR;

    public class EditApartmentAdCommand : ApartmentAdCommand<EditApartmentAdCommand>, IRequest<Result>
    {
        public class EditApartmentAdCommandHandler : IRequestHandler<EditApartmentAdCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IApartmentAdRepository apartmentAdRepository;
            private readonly IBrokerRepository brokerRepository;

            public EditApartmentAdCommandHandler(
                ICurrentUser currentUser, 
                IApartmentAdRepository apartmentAdRepository, 
                IBrokerRepository brokerRepository)
            {
                this.currentUser = currentUser;
                this.apartmentAdRepository = apartmentAdRepository;
                this.brokerRepository = brokerRepository;
            }

            public async Task<Result> Handle(
                EditApartmentAdCommand request, 
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

                var category = await this.apartmentAdRepository.GetCategory(
                    request.Category, 
                    cancellationToken);

                var apartmentAd = await this.apartmentAdRepository
                    .Find(request.Id, cancellationToken);

                apartmentAd
                    .UpdateNeighborhood(request.Neighborhood)
                    .UpdateFloor(request.Floor)
                    .UpdateCategory(category)
                    .UpdateImageUrl(request.ImageUrl)
                    .UpdatePricePerMonth(request.PricePerMonth)
                    .UpdateOptions(
                        request.HasParking,
                        request.HasBasement,
                        Enumeration.FromValue<HeatingType>(request.HeatingType));

                await this.apartmentAdRepository.Save(apartmentAd, cancellationToken);

                return Result.Success;
            }
        }
    }
}
