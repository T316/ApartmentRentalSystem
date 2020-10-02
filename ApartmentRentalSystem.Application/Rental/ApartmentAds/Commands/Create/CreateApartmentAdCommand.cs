namespace ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Common.Contracts;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds;
    using ApartmentRentalSystem.Application.Rental.Brokers;
    using ApartmentRentalSystem.Domain.Common.Models;
    using ApartmentRentalSystem.Domain.Rental.Factories.ApartmentAds;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using MediatR;

    public class CreateApartmentAdCommand : IRequest<CreateApartmentAdOutputModel>
    {
        public CreateApartmentAdCommand(
            string neighborhood,
            int floor,
            int category,
            string imageUrl,
            decimal pricePerMonth,
            bool hasParking,
            bool hasBasement,
            int heatingType)
        {
            Neighborhood = neighborhood;
            Floor = floor;
            Category = category;
            ImageUrl = imageUrl;
            PricePerMonth = pricePerMonth;
            HasParking = hasParking;
            HasBasement = hasBasement;
            HeatingType = heatingType;
        }

        public string Neighborhood { get; }

        public int Floor { get; }

        public int Category { get; }

        public string ImageUrl { get; }

        public decimal PricePerMonth { get; }

        public bool HasParking { get; }

        public bool HasBasement { get; }

        public int HeatingType { get; }

        public class CreateApartmentAdCommandHandler : IRequestHandler<CreateApartmentAdCommand, CreateApartmentAdOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IBrokerRepository brokerRepository;
            private readonly IApartmentAdRepository apartmentAdRepository;
            private readonly IApartmentAdFactory apartmentAdFactory;

            public CreateApartmentAdCommandHandler(
                ICurrentUser currentUser,
                IBrokerRepository brokerRepository,
                IApartmentAdRepository apartmentAdRepository,
                IApartmentAdFactory apartmentAdFactory)
            {
                this.currentUser = currentUser;
                this.brokerRepository = brokerRepository;
                this.apartmentAdRepository = apartmentAdRepository;
                this.apartmentAdFactory = apartmentAdFactory;
            }

            public async Task<CreateApartmentAdOutputModel> Handle(
                CreateApartmentAdCommand request,
                CancellationToken cancellationToken)
            {
                var userId = currentUser.UserId;
                var broker = await brokerRepository.FindByUser(userId, cancellationToken);

                var category = await apartmentAdRepository.GetCategory(request.Category, cancellationToken);

                var neighborhood = await apartmentAdRepository.GetNeighborhood(request.Neighborhood, cancellationToken);

                var factory = neighborhood == null
                    ? apartmentAdFactory.WithNeighborhood(request.Neighborhood)
                    : apartmentAdFactory.WithNeighborhood(neighborhood);

                var ApartmentAd = factory
                    .WithFloor(request.Floor)
                    .WithCategory(category)
                    .WithImageUrl(request.ImageUrl)
                    .WithPricePerMonth(request.PricePerMonth)
                    .WithOptions(
                        request.HasParking,
                        request.HasBasement,
                        Enumeration.FromValue<HeatingType>(request.HeatingType))
                    .Build();

                broker.AddApartmentAd(ApartmentAd);

                await apartmentAdRepository.Save(ApartmentAd, cancellationToken);

                return new CreateApartmentAdOutputModel(ApartmentAd.Id);
            }
        }
    }
}
