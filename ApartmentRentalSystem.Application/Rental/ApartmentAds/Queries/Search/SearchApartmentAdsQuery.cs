namespace ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Search
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Features.ApartmentAds;
    using ApartmentRentalSystem.Domain.Rental.Specifications.ApartmentAds;
    using MediatR;

    public class SearchApartmentAdsQuery : IRequest<SearchApartmentAdsOutputModel>
    {
        public string? Neighborhood { get; set; }

        public int? Category { get; set; }

        public decimal? MinPricePerMonth { get; set; }

        public decimal? MaxPricePerMonth { get; set; }

        public class SearchApartmentAdsQueryHandler : IRequestHandler<
            SearchApartmentAdsQuery,
            SearchApartmentAdsOutputModel>
        {
            private readonly IApartmentAdRepository apartmentAdRepository;

            public SearchApartmentAdsQueryHandler(IApartmentAdRepository apartmentAdRepository)
                => this.apartmentAdRepository = apartmentAdRepository;

            public async Task<SearchApartmentAdsOutputModel> Handle
                (SearchApartmentAdsQuery request,
                CancellationToken cancellationToken)
            {
                var apartmentAdSpecification = new ApartmentAdByNeighborhoodSpecification(request.Neighborhood)
                   .And(new ApartmentAdByCategorySpecification(request.Category))
                   .And(new ApartmentAdByPricePerDaySpecification(request.MinPricePerMonth, request.MaxPricePerMonth));

                var apartmentAdListings = await apartmentAdRepository.GetApartmentAdListings(
                    apartmentAdSpecification,
                    cancellationToken);

                var totalApartmentAds = await apartmentAdRepository.Total(cancellationToken);

                return new SearchApartmentAdsOutputModel(apartmentAdListings, totalApartmentAds);
            }
        }
    }
}
