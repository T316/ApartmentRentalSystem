namespace ApartmentRentalSystem.Domain.Statistics.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;

    public class Statistics : IAggregateRoot
    {
        private readonly HashSet<ApartmentAdView> apartmentAdViews;

        internal Statistics()
        {
            this.TotalApartmentAds = 0;

            this.apartmentAdViews = new HashSet<ApartmentAdView>();
        }

        public int TotalApartmentAds { get; private set; }

        public IReadOnlyCollection<ApartmentAdView> ApartmentAdViews
            => this.apartmentAdViews.ToList().AsReadOnly();

        public void AddApartmentAd()
            => this.TotalApartmentAds++;

        public void AddApartmentAdView(int apartmentAdId, string? userId)
            => this.apartmentAdViews.Add(new ApartmentAdView(apartmentAdId, userId));
    }
}
