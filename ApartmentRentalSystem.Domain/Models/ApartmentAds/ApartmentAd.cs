namespace ApartmentRentalSystem.Domain.Models.ApartmentAds
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Exceptions;
    using static ModelConstants.Common;
    using static ModelConstants.ApartmentAd;

    public class ApartmentAd : Entity<int>, IAggregateRoot
    {
        private static readonly IEnumerable<Category> AllowedCategories
            = new CategoryData().GetData().Cast<Category>();

        internal ApartmentAd( 
            Neighborhood neighborhood, 
            int floor, 
            Category category,
            string imageUrl, 
            decimal pricePerMonth,
            Options options,
            bool isAvailable)
        {
            this.Validate(floor, imageUrl, pricePerMonth);
            this.ValidateCategory(category);

            this.Neighborhood = neighborhood;
            this.Floor = floor;
            this.Category = category;
            this.ImageUrl = imageUrl;
            this.PricePerMonth = pricePerMonth;
            this.Options = options;
            this.IsAvailable = isAvailable;
        }

        private ApartmentAd(
            int floor,
            string imageUrl,
            decimal pricePerMonth,
            bool isAvailable)
        {
            this.Floor = floor;
            this.ImageUrl = imageUrl;
            this.PricePerMonth = pricePerMonth;
            this.IsAvailable = isAvailable;

            this.Neighborhood = default!;
            this.Category = default!;
            this.Options = default!;
        }

        public Neighborhood Neighborhood { get; private set; }

        public int Floor { get; private set; }

        public Category Category { get; private set; }

        public string ImageUrl { get; private set; }

        public decimal PricePerMonth { get; private set; }

        public Options Options { get; private set; }

        public bool IsAvailable { get; private set; }

        public ApartmentAd UpdateNeighborhood(string neighborhood)
        {
            if (this.Neighborhood.Name != neighborhood)
            {
                this.Neighborhood = new Neighborhood(neighborhood);
            }

            return this;
        }

        public ApartmentAd UpdateFloor(int floor)
        {
            this.ValidateFloor(floor);
            this.Floor = floor;

            return this;
        }

        public ApartmentAd UpdateCategory(Category category)
        {
            this.ValidateCategory(category);
            this.Category = category;

            return this;
        }

        public ApartmentAd UpdateImageUrl(string imageUrl)
        {
            this.ValidateImageUrl(imageUrl);
            this.ImageUrl = imageUrl;

            return this;
        }

        public ApartmentAd UpdatepricePerMonth(decimal pricePerMonth)
        {
            this.ValidatepricePerMonth(pricePerMonth);
            this.PricePerMonth = pricePerMonth;

            return this;
        }
        
        public ApartmentAd UpdateOptions(
            bool hasParking,
            bool hasBasement,
            HeatingType heatingType)
        {
            this.Options = new Options(hasParking, hasBasement, heatingType);

            return this;
        }

        public ApartmentAd ChangeAvailability()
        {
            this.IsAvailable = !this.IsAvailable;

            return this;
        }

        private void Validate(int floor, string imageUrl, decimal pricePerMonth)
        {
            this.ValidateFloor(floor);
            this.ValidateImageUrl(imageUrl);
            this.ValidatepricePerMonth(pricePerMonth);
        }

        private void ValidateFloor(int floor)
            => Guard.AgainstOutOfRange<InvalidApartmentAdException>(
                floor,
                MinFloor,
                MaxFloor,
                nameof(this.Floor));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidApartmentAdException>(
                imageUrl,
                nameof(this.ImageUrl));

        private void ValidatepricePerMonth(decimal pricePerMonth)
            => Guard.AgainstOutOfRange<InvalidApartmentAdException>(
                pricePerMonth,
                Zero,
                decimal.MaxValue,
                nameof(this.PricePerMonth));

        private void ValidateCategory(Category category)
        {
            var categoryName = category?.Name;

            if (AllowedCategories.Any(c => c.Name == categoryName))
            {
                return;
            }

            var allowedCategoryNames = string.Join(", ", AllowedCategories.Select(c => $"'{c.Name}'"));

            throw new InvalidApartmentAdException($"'{categoryName}' is not a valid category. Allowed values are: {allowedCategoryNames}.");
        }
    }
}
