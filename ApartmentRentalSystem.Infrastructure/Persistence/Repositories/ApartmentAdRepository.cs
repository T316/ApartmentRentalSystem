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
    using AutoMapper;
    using ApartmentRentalSystem.Domain.Specifications;

    internal class ApartmentAdRepository : DataRepository<ApartmentAd>, IApartmentAdRepository
    {
        private readonly IMapper mapper;

        public ApartmentAdRepository(ApartmentRentalDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<IEnumerable<ApartmentAdListingModel>> GetApartmentAdListings(
            Specification<ApartmentAd> specification,
            CancellationToken cancellationToken = default)
                => await this.mapper
                    .ProjectTo<ApartmentAdListingModel>(this
                        .AllAvailable()
                    .Where(specification))
                    .ToListAsync(cancellationToken);

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
