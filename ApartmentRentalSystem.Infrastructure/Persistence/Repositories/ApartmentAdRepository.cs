namespace ApartmentRentalSystem.Infrastructure.Persistence.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Application.Features.ApartmentAds;
    using Application.Features.ApartmentAds.Queries.Search;
    using Domain.Models.ApartmentAds;

    internal class ApartmentAdRepository : DataRepository<ApartmentAd>, IApartmentAdRepository
    {
        public ApartmentAdRepository(ApartmentRentalDbContext db)
            : base(db)
        {
        }

        public async Task<IEnumerable<ApartmentAdListingModel>> GetApartmentAdListings(
            string? neighborhood = default,
            CancellationToken cancellationToken = default)
        {
            var query = this.AllAvailable();

            if (!string.IsNullOrWhiteSpace(neighborhood))
            {
                query = query
                    .Where(apartment => EF
                        .Functions
                        .Like(apartment.Neighborhood.Name, $"%{neighborhood}%"));
            }

            return await query
                .Select(apartment => new ApartmentAdListingModel(
                    apartment.Id,
                    apartment.Neighborhood.Name,
                    apartment.Floor,
                    apartment.ImageUrl,
                    apartment.Category.Name,
                    apartment.pricePerMonth))
                .ToListAsync(cancellationToken);
        }

        public async Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default)
            => await this
                .Data
                .Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

        public async Task<Neighborhood> GetNeighborhood(
            string neighborhood,
            CancellationToken cancellationToken = default)
            => await this
                .Data
                .Neighborhoods
                .FirstOrDefaultAsync(m => m.Name == neighborhood, cancellationToken);

        public async Task<int> Total(CancellationToken cancellationToken = default)
            => await this
                .AllAvailable()
                .CountAsync(cancellationToken);

        private IQueryable<ApartmentAd> AllAvailable()
            => this
                .All()
                .Where(apartment => apartment.IsAvailable);
    }
}
