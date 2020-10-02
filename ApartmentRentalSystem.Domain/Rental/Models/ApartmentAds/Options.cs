namespace ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds
{
    using ApartmentRentalSystem.Domain.Common.Models;

    public class Options : ValueObject
    {
        internal Options(bool hasParking, bool hasBasement, HeatingType heatingType)
        {
            HasParking = hasParking;
            HasBasement = hasBasement;
            HeatingType = heatingType;
        }

        private Options(bool hasParking, bool hasBasement)
        {
            HasParking = hasParking;
            HasBasement = hasBasement;

            HeatingType = default!;
        }

        public bool HasParking { get; }

        public bool HasBasement { get; }

        public HeatingType HeatingType { get; }
    }
}
