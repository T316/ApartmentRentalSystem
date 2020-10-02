namespace ApartmentRentalSystem.Application.Rental.Brokers
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Brokerships.Brokers.Queries.Common;
    using ApartmentRentalSystem.Application.Brokerships.Brokers.Queries.Details;
    using ApartmentRentalSystem.Application.Common.Contracts;
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;

    public interface IBrokerRepository : IRepository<Broker>
    {
        Task<Broker> FindByUser(string userId, CancellationToken cancellationToken = default);

        Task<int> GetBrokerId(string userId, CancellationToken cancellationToken = default);

        Task<bool> HasApartmentAd(int brokerId, int apartmentAdId, CancellationToken cancellationToken = default);

        Task<BrokerDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<BrokerOutputModel> GetDetailsByApartmentId(int apartmentAdId, CancellationToken cancellationToken = default);
    }
}
