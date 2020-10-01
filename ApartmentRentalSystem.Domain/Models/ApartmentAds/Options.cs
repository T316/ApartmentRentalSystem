namespace ApartmentRentalSystem.Domain.Models.ApartmentAds
{
    using Common;

    public class Options : ValueObject
    {
        internal Options(bool hasParking, bool hasBasement, HeatingType heatingType)
        {
            this.HasParking = hasParking;
            this.HasBasement = hasBasement;
            this.HeatingType = heatingType;
        }

        private Options(bool hasParking, bool hasBasement)
        {
            this.HasParking = hasParking;
            this.HasBasement = hasBasement;

            this.HeatingType = default!;
        }

        public bool HasParking { get; }

        public bool HasBasement { get; }

        public HeatingType HeatingType { get; }
    }
}
