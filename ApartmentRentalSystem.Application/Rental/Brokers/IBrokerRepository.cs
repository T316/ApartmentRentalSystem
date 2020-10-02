namespace ApartmentRentalSystem.Application.Rental.Brokers
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Common.Contracts;
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;

    public interface IBrokerRepository : IRepository<Broker>
    {
        Task<Broker> FindByUser(string userId, CancellationToken cancellationToken = default);
    }
}
