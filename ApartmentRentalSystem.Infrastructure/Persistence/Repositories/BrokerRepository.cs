namespace ApartmentRentalSystem.Infrastructure.Persistence.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Persistence;
    using Domain.Exceptions;
    using Domain.Models.Brokers;
    using Microsoft.EntityFrameworkCore;
    using ApartmentRentalSystem.Application.Features.Brokers;

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
            var broker = await this
                .Data
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
