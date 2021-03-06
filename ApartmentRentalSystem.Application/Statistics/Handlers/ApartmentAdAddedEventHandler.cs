﻿namespace ApartmentRentalSystem.Application.Statistics.Handlers
{
    using System.Threading.Tasks;
    using Common;
    using Domain.Brokerships.Events.Brokers;

    public class ApartmentAdAddedEventHandler : IEventHandler<ApartmentAdAddedEvent>
    {
        private readonly IStatisticsRepository statistics;

        public ApartmentAdAddedEventHandler(IStatisticsRepository statistics) 
            => this.statistics = statistics;

        public Task Handle(ApartmentAdAddedEvent domainEvent)
            => this.statistics.IncrementApartmentAds();
    }
}
