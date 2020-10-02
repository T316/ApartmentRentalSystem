namespace ApartmentRentalSystem.Infrastructure.Rental.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Application.Features.ApartmentAds;
    using AutoMapper;
    using ApartmentRentalSystem.Domain.Common;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Search;
    using ApartmentRentalSystem.Infrastructure.Common.Persistence;

    internal class ApartmentAdRepository : DataRepository<ApartmentAd>, IApartmentAdRepository
    {
        private readonly IMapper mapper;

        public ApartmentAdRepository(ApartmentRentalDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<IEnumerable<ApartmentAdListingModel>> GetApartmentAdListings(
            Specification<ApartmentAd> specification,
            CancellationToken cancellationToken = default)
                => await mapper
                    .ProjectTo<ApartmentAdListingModel>(
                        AllAvailable()
                    .Where(specification))
                    .ToListAsync(cancellationToken);

        public async Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default)
            => await
                Data
                .Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

        public async Task<Neighborhood> GetNeighborhood(
            string neighborhood,
            CancellationToken cancellationToken = default)
            => await
                Data
                .Neighborhoods
                .FirstOrDefaultAsync(m => m.Name == neighborhood, cancellationToken);

        public async Task<int> Total(CancellationToken cancellationToken = default)
            => await
                AllAvailable()
                .CountAsync(cancellationToken);

        private IQueryable<ApartmentAd> AllAvailable()
            =>
                All()
                .Where(apartment => apartment.IsAvailable);
    }
}
