namespace ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds
{
    using Exceptions;
    using ApartmentRentalSystem.Domain.Common.Models;
    using static ModelConstants.Common;
    using static ModelConstants.Category;

    public class Category : Entity<int>
    {
        internal Category(string name, string description)
        {
            Validate(name, description);

            Name = name;
            Description = description;
        }

        public string Name { get; }

        public string Description { get; }

        private void Validate(string name, string description)
        {
            Guard.ForStringLength<InvalidApartmentAdException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(Name));

            Guard.ForStringLength<InvalidApartmentAdException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(Description));
        }
    }
}
