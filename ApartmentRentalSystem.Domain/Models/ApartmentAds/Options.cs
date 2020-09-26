namespace ApartmentRentalSystem.Domain.Models.ApartmentAds
{
    using Common;

    public class Options : ValueObject
    {
        internal Options(bool hasParking, bool hasBasement, HheatingType hheatingType)
        {
            this.HasParking = hasParking;
            this.HasBasement = hasBasement;
            this.HheatingType = hheatingType;
        }

        private Options(bool hasParking, bool hasBasement)
        {
            this.HasParking = hasParking;
            this.HasBasement = hasBasement;

            this.HheatingType = default!;
        }

        public bool HasParking { get; }

        public bool HasBasement { get; }

        public HheatingType HheatingType { get; }
    }
}
