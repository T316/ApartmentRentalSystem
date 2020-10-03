namespace ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Exceptions;
    using ApartmentRentalSystem.Domain.Common.Models;
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
            Validate(floor, imageUrl, pricePerMonth);
            ValidateCategory(category);

            Neighborhood = neighborhood;
            Floor = floor;
            Category = category;
            ImageUrl = imageUrl;
            PricePerMonth = pricePerMonth;
            Options = options;
            IsAvailable = isAvailable;
        }

        private ApartmentAd(
            int floor,
            string imageUrl,
            decimal pricePerMonth,
            bool isAvailable)
        {
            Floor = floor;
            ImageUrl = imageUrl;
            PricePerMonth = pricePerMonth;
            IsAvailable = isAvailable;

            Neighborhood = default!;
            Category = default!;
            Options = default!;
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
            if (Neighborhood.Name != neighborhood)
            {
                Neighborhood = new Neighborhood(neighborhood);
            }

            return this;
        }

        public ApartmentAd UpdateFloor(int floor)
        {
            ValidateFloor(floor);
            Floor = floor;

            return this;
        }

        public ApartmentAd UpdateCategory(Category category)
        {
            ValidateCategory(category);
            Category = category;

            return this;
        }

        public ApartmentAd UpdateImageUrl(string imageUrl)
        {
            ValidateImageUrl(imageUrl);
            ImageUrl = imageUrl;

            return this;
        }

        public ApartmentAd UpdatePricePerMonth(decimal pricePerMonth)
        {
            ValidatepricePerMonth(pricePerMonth);
            PricePerMonth = pricePerMonth;

            return this;
        }

        public ApartmentAd UpdateOptions(
            bool hasParking,
            bool hasBasement,
            HeatingType heatingType)
        {
            Options = new Options(hasParking, hasBasement, heatingType);

            return this;
        }

        public ApartmentAd ChangeAvailability()
        {
            IsAvailable = !IsAvailable;

            return this;
        }

        private void Validate(int floor, string imageUrl, decimal pricePerMonth)
        {
            ValidateFloor(floor);
            ValidateImageUrl(imageUrl);
            ValidatepricePerMonth(pricePerMonth);
        }

        private void ValidateFloor(int floor)
            => Guard.AgainstOutOfRange<InvalidApartmentAdException>(
                floor,
                MinFloor,
                MaxFloor,
                nameof(Floor));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidApartmentAdException>(
                imageUrl,
                nameof(ImageUrl));

        private void ValidatepricePerMonth(decimal pricePerMonth)
            => Guard.AgainstOutOfRange<InvalidApartmentAdException>(
                pricePerMonth,
                Zero,
                decimal.MaxValue,
                nameof(PricePerMonth));

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
