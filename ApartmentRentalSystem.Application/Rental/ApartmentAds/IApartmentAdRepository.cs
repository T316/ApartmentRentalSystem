namespace ApartmentRentalSystem.Application.Rental.ApartmentAds
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Common.Contracts;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Details;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Search;
    using ApartmentRentalSystem.Domain.Common;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;

    public interface IApartmentAdRepository : IRepository<ApartmentAd>
    {
        Task<ApartmentAd> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<ApartmentAdListingModel>> GetApartmentAdListings(
            Specification<ApartmentAd> spefication,
            CancellationToken cancellationToken = default);

        Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default);

        Task<Neighborhood> GetNeighborhood(
            string neighborhood,
            CancellationToken cancellationToken = default);

        Task<ApartmentAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<int> Total(CancellationToken cancellationToken = default);
    }
}
