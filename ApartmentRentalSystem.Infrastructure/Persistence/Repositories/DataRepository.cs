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
        private readonly ApartmentRentalDbContext db;

        public DataRepository(ApartmentRentalDbContext db) => this.db = db;

        public IQueryable<TEntity> All() => this.db.Set<TEntity>();
    }
}
