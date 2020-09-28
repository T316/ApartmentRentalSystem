namespace ApartmentRentalSystem.Application.Features.ApartmentAds.Queries.Search
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    public class SearchApartmentAdsQuery : IRequest<SearchApartmentAdsOutputModel>
    {
        public string? Neighborhood { get; set; }

        public class SearchCarAdsQueryHandler : IRequestHandler<
            SearchApartmentAdsQuery,
            SearchApartmentAdsOutputModel>
        {
            private readonly IApartmentAdRepository apartmentAdRepository;

            public SearchCarAdsQueryHandler(IApartmentAdRepository apartmentAdRepository)
                => this.apartmentAdRepository = apartmentAdRepository;

            public async Task<SearchApartmentAdsOutputModel> Handle
                (SearchApartmentAdsQuery request, 
                CancellationToken cancellationToken)
            {
                var apartmentAdListings = await this.apartmentAdRepository.GetApartmentAdListings(
                    request.Neighborhood,
                    cancellationToken);

                var totalApartmentAds = await this.apartmentAdRepository.Total(cancellationToken);

                return new SearchApartmentAdsOutputModel(apartmentAdListings, totalApartmentAds);
            }
        }
    }
}
