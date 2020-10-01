namespace ApartmentRentalSystem.Application.Features.Brokers
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Contracts;
    using ApartmentRentalSystem.Domain.Models.Brokers;
    public interface IBrokerRepository : IRepository<Broker>
    {
        Task<Broker> FindByUser(string userId, CancellationToken cancellationToken = default);
    }
}
