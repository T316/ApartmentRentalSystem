namespace ApartmentRentalSystem.Application.Features.ApartmentAds
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ApartmentRentalSystem.Domain.Specifications;
    using Contracts;
    using Domain.Models.ApartmentAds;
    using Queries.Search;

    public interface IApartmentAdRepository : IRepository<ApartmentAd>
    {
        Task<IEnumerable<ApartmentAdListingModel>> GetApartmentAdListings(
            Specification<ApartmentAd> spefication,
            CancellationToken cancellationToken = default);

        Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default);

        Task<Neighborhood> GetNeighborhood(
            string neighborhood,
            CancellationToken cancellationToken = default);

        Task<int> Total(CancellationToken cancellationToken = default);
    }
}
