namespace ApartmentRentalSystem.Domain.Rental.Factories.ApartmentAds
{
    using ApartmentRentalSystem.Domain.Rental.Exceptions;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;

    internal class ApartmentAdFactory : IApartmentAdFactory
    {
        private Neighborhood apartmentAdNeighborhood = default!;
        private int apartmentAdFloor = default!;
        private Category apartmentAdCategory = default!;
        private string apartmentAdImageUrl = default!;
        private decimal apartmentAdPricePerMonth = default!;
        private Options apartmentAdOptions = default!;

        private bool NeighborhoodSet = false;
        private bool categorySet = false;
        private bool optionsSet = false;

        public IApartmentAdFactory WithNeighborhood(string name)
            => WithNeighborhood(new Neighborhood(name));

        public IApartmentAdFactory WithNeighborhood(Neighborhood Neighborhood)
        {
            apartmentAdNeighborhood = Neighborhood;
            NeighborhoodSet = true;
            return this;
        }

        public IApartmentAdFactory WithFloor(int Floor)
        {
            apartmentAdFloor = Floor;
            return this;
        }

        public IApartmentAdFactory WithCategory(string name, string description)
            => WithCategory(new Category(name, description));

        public IApartmentAdFactory WithCategory(Category category)
        {
            apartmentAdCategory = category;
            categorySet = true;
            return this;
        }

        public IApartmentAdFactory WithImageUrl(string imageUrl)
        {
            apartmentAdImageUrl = imageUrl;
            return this;
        }

        public IApartmentAdFactory WithPricePerMonth(decimal pricePerMonth)
        {
            apartmentAdPricePerMonth = pricePerMonth;
            return this;
        }

        public IApartmentAdFactory WithOptions(bool hasParking, bool hasBasement, HeatingType heatingType)
            => WithOptions(new Options(hasParking, hasBasement, heatingType));

        public IApartmentAdFactory WithOptions(Options options)
        {
            apartmentAdOptions = options;
            optionsSet = true;
            return this;
        }

        public ApartmentAd Build()
        {
            if (!NeighborhoodSet || !categorySet || !optionsSet)
            {
                throw new InvalidApartmentAdException("Neighborhood, category and options must have a value.");
            }

            return new ApartmentAd(
                apartmentAdNeighborhood,
                apartmentAdFloor,
                apartmentAdCategory,
                apartmentAdImageUrl,
                apartmentAdPricePerMonth,
                apartmentAdOptions,
                true);
        }
    }
}
