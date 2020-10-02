namespace ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds
{
    using ApartmentRentalSystem.Domain.Common.Models;
    using ApartmentRentalSystem.Domain.Rental.Exceptions;
    using static ModelConstants.Common;

    public class Neighborhood : Entity<int>
    {
        internal Neighborhood(string name)
        {
            Validate(name);

            Name = name;
        }

        public string Name { get; private set; }

        public Neighborhood UpdateName(string name)
        {
            Validate(name);
            Name = name;

            return this;
        }

        public void Validate(string newName)
            => Guard.ForStringLength<InvalidApartmentAdException>(
                newName,
                MinNameLength,
                MaxNameLength,
                nameof(Name));
    }
}
