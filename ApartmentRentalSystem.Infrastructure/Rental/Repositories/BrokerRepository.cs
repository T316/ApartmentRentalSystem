namespace ApartmentRentalSystem.Infrastructure.Rental.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ApartmentRentalSystem.Domain.Rental.Exceptions;
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;
    using ApartmentRentalSystem.Application.Rental.Brokers;
    using ApartmentRentalSystem.Infrastructure.Common.Persistence;
    using AutoMapper;
    using ApartmentRentalSystem.Application.Brokerships.Brokers.Queries.Details;
    using ApartmentRentalSystem.Application.Brokerships.Brokers.Queries.Common;
    using ApartmentRentalSystem.Infrastructure.Identity;

    internal class BrokerRepository : DataRepository<IRentalDbContext, Broker>, IBrokerRepository
    {
        private readonly IMapper mapper;

        public BrokerRepository(IRentalDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<bool> HasApartmentAd(int brokerId, int apartmentAdId, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(d => d.Id == brokerId)
                .AnyAsync(d => d.ApartmentAds
                    .Any(c => c.Id == apartmentAdId), cancellationToken);

        public async Task<BrokerDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<BrokerDetailsOutputModel>(this
                    .All()
                    .Where(d => d.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<BrokerOutputModel> GetDetailsByApartmentId(int apartmentAdId, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<BrokerOutputModel>(this
                    .All()
                    .Where(d => d.ApartmentAds.Any(c => c.Id == apartmentAdId)))
                .SingleOrDefaultAsync(cancellationToken);

        public Task<int> GetBrokerId(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, user => user.Broker!.Id, cancellationToken);

        public Task<Broker> FindByUser(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, user => user.Broker!, cancellationToken);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<User, T>> selector,
            CancellationToken cancellationToken = default)
        {
            var brokerData = await this
                .Data
                .Users
                .Where(u => u.Id == userId)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);

            if (brokerData == null)
            {
                throw new InvalidBrokerException("This user is not a broker.");
            }

            return brokerData;
        }
    }
}