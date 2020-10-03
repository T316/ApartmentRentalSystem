namespace ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Common
{
    using ApartmentRentalSystem.Application.Common;

    public abstract class ApartmentAdCommand<TCommand> : EntityCommand<int>
       where TCommand : EntityCommand<int>
    {
        public string Neighborhood { get; set; } = default!;

        public int Floor { get; set; } = default!;

        public int Category { get; set; }

        public string ImageUrl { get; set; } = default!;

        public decimal PricePerMonth { get; set; }

        public bool HasParking { get; set; }

        public bool HasBasement { get; set; }

        public int HeatingType { get; set; }
    }
}
