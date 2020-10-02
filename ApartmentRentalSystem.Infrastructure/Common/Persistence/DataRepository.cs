namespace ApartmentRentalSystem.Infrastructure.Common.Persistence
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ApartmentRentalSystem.Application.Common.Contracts;
    using ApartmentRentalSystem.Domain.Common;

    internal abstract class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        public DataRepository(ApartmentRentalDbContext db) => Data = db;

        public ApartmentRentalDbContext Data { get; }

        public IQueryable<TEntity> All() => Data.Set<TEntity>();

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            Data.Add(entity);

            await Data.SaveChangesAsync(cancellationToken);
        }
    }
}
