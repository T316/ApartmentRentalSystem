namespace ApartmentRentalSystem.Infrastructure.Rental.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using ApartmentRentalSystem.Domain.Common;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Search;
    using ApartmentRentalSystem.Infrastructure.Common.Persistence;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Details;

    internal class ApartmentAdRepository : DataRepository<IRentalDbContext, ApartmentAd>, IApartmentAdRepository
    {
        private readonly IMapper mapper;

        public ApartmentAdRepository(IRentalDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<ApartmentAd> Find(int id, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Include(c => c.Neighborhood)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var apartmentAd = await this.Data.ApartmentAds.FindAsync(id);

            if (apartmentAd == null)
            {
                return false;
            }

            this.Data.ApartmentAds.Remove(apartmentAd);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

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

        public async Task<ApartmentAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<ApartmentAdDetailsOutputModel>(this
                    .AllAvailable()
                    .Where(c => c.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

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
