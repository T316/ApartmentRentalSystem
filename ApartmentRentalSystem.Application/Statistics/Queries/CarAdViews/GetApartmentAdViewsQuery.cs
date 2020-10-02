namespace ApartmentRentalSystem.Application.Statistics.Queries.ApartmentAdViews
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetApartmentAdViewsQuery : IRequest<int>
    {
        public int ApartmentAdId { get; set; }

        public class GetApartmentAdViewsQueryHandler : IRequestHandler<GetApartmentAdViewsQuery, int>
        {
            private readonly IStatisticsRepository statistics;

            public GetApartmentAdViewsQueryHandler(IStatisticsRepository statistics) 
                => this.statistics = statistics;

            public Task<int> Handle(
                GetApartmentAdViewsQuery request, 
                CancellationToken cancellationToken)
                => this.statistics.GetApartmentAdViews(request.ApartmentAdId, cancellationToken);
        }
    }
}
