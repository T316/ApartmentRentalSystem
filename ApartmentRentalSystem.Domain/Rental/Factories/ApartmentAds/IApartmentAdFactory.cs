namespace ApartmentRentalSystem.Domain.Rental.Factories.ApartmentAds
{
    using ApartmentRentalSystem.Domain.Common;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;

    public interface IApartmentAdFactory : IFactory<ApartmentAd>
    {
        IApartmentAdFactory WithNeighborhood(string name);

        IApartmentAdFactory WithNeighborhood(Neighborhood neighborhood);

        IApartmentAdFactory WithFloor(int floor);

        IApartmentAdFactory WithCategory(string name, string description);

        IApartmentAdFactory WithCategory(Category category);

        IApartmentAdFactory WithImageUrl(string imageUrl);

        IApartmentAdFactory WithPricePerMonth(decimal pricePerMonth);

        IApartmentAdFactory WithOptions(
            bool hasParking,
            bool hasBasement,
            HeatingType heatingType);
    }
}
