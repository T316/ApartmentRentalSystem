namespace ApartmentRentalSystem.Infrastructure.Persistence.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ApartmentRentalSystem.Application.Contracts;
    using ApartmentRentalSystem.Domain.Common;

    internal abstract class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        public DataRepository(ApartmentRentalDbContext db) => this.Data = db;

        public ApartmentRentalDbContext Data { get; }

        public IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Add(entity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
