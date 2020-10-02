namespace ApartmentRentalSystem.Infrastructure.Statistics.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;

    using Application.Statistics;
    using Application.Statistics.Queries.Current;
    using AutoMapper;
    using Common.Persistence;
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;

    internal class StatisticsRepository : DataRepository<IStatisticsDbContext, Statistics>, IStatisticsRepository
    {
        private readonly IMapper mapper;

        public StatisticsRepository(IStatisticsDbContext db, IMapper mapper)
            : base(db) 
            => this.mapper = mapper;

        public async Task<GetCurrentStatisticsOutputModel> GetCurrent(CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetCurrentStatisticsOutputModel>(this.All())
                .SingleOrDefaultAsync(cancellationToken);

        public async Task<int> GetApartmentAdViews(int apartmentAdId, CancellationToken cancellationToken = default)
            => await this.Data
                .ApartmentAdViews
                .CountAsync(cav => cav.ApartmentAdId == apartmentAdId, cancellationToken);

        public async Task IncrementApartmentAds(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data
                .Statistics
                .SingleOrDefaultAsync(cancellationToken);

            statistics.AddApartmentAd();

            await this.Save(statistics, cancellationToken);
        }
    }
}
