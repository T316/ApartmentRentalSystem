namespace ApartmentRentalSystem.Domain.Statistics.Models
{
    using Common.Models;

    public class ApartmentAdView : Entity<int>
    {
        internal ApartmentAdView(int apartmentAdId, string? userId)
        {
            this.ApartmentAdId = apartmentAdId;
            this.UserId = userId;
        }

        public int ApartmentAdId { get; }

        public string? UserId { get; }
    }
}
