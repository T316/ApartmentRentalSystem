namespace ApartmentRentalSystem.Domain.Factories.ApartmentAds
{
    using ApartmentRentalSystem.Domain.Exceptions;
    using Models.ApartmentAds;

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
            => this.WithNeighborhood(new Neighborhood(name));

        public IApartmentAdFactory WithNeighborhood(Neighborhood Neighborhood)
        {
            this.apartmentAdNeighborhood = Neighborhood;
            this.NeighborhoodSet = true;
            return this;
        }

        public IApartmentAdFactory WithFloor(int Floor)
        {
            this.apartmentAdFloor = Floor;
            return this;
        }

        public IApartmentAdFactory WithCategory(string name, string description)
            => this.WithCategory(new Category(name, description));

        public IApartmentAdFactory WithCategory(Category category)
        {
            this.apartmentAdCategory = category;
            this.categorySet = true;
            return this;
        }

        public IApartmentAdFactory WithImageUrl(string imageUrl)
        {
            this.apartmentAdImageUrl = imageUrl;
            return this;
        }

        public IApartmentAdFactory WithPricePerMonth(decimal pricePerMonth)
        {
            this.apartmentAdPricePerMonth = pricePerMonth;
            return this;
        }

        public IApartmentAdFactory WithOptions(bool hasParking, bool hasBasement, HeatingType heatingType)
            => this.WithOptions(new Options(hasParking, hasBasement, heatingType));

        public IApartmentAdFactory WithOptions(Options options)
        {
            this.apartmentAdOptions = options;
            this.optionsSet = true;
            return this;
        }

        public ApartmentAd Build()
        {
            if (!this.NeighborhoodSet || !this.categorySet || !this.optionsSet)
            {
                throw new InvalidApartmentAdException("Neighborhood, category and options must have a value.");
            }

            return new ApartmentAd(
                this.apartmentAdNeighborhood,
                this.apartmentAdFloor,
                this.apartmentAdCategory,
                this.apartmentAdImageUrl,
                this.apartmentAdPricePerMonth,
                this.apartmentAdOptions,
                true);
        }
    }
}
