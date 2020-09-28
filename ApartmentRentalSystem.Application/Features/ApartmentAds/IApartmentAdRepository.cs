namespace ApartmentRentalSystem.Application.Features.ApartmentAds
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Models.ApartmentAds;
    using Queries.Search;

    public interface IApartmentAdRepository : IRepository<ApartmentAd>
    {
        Task<IEnumerable<ApartmentAdListingModel>> GetApartmentAdListings(
            string? neighborhood = default,
            CancellationToken cancellationToken = default);

        Task<int> Total(CancellationToken cancellationToken = default);
    }
}
