namespace ApartmentRentalSystem.Infrastructure.Rental.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ApartmentRentalSystem.Domain.Rental.Exceptions;
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;
    using ApartmentRentalSystem.Application.Rental.Brokers;
    using ApartmentRentalSystem.Infrastructure.Common.Persistence;

    internal class BrokerRepository : DataRepository<Broker>, IBrokerRepository
    {
        public BrokerRepository(ApartmentRentalDbContext db)
            : base(db)
        {
        }

        public async Task<Broker> FindByUser(
            string userId,
            CancellationToken cancellationToken = default)
        {
            var broker = await
                Data
                .Users
                .Where(u => u.Id == userId)
                .Select(u => u.Broker)
                .FirstOrDefaultAsync(cancellationToken);

            if (broker == null)
            {
                throw new InvalidBrokerException("This user is not a broker.");
            }

            return broker;
        }
    }
}
