namespace ApartmentRentalSystem.Domain.Models.ApartmentAds
{
    using Common;
    using Exceptions;
    using static ModelConstants.Common;

    public class Neighborhood : Entity<int>
    {
        internal Neighborhood(string name)
        { 
            this.Validate(name);

            this.Name = name;
        }

        public string Name { get; private set; }

        public Neighborhood UpdateName(string name)
        {
            this.Validate(name);
            this.Name = name;

            return this;
        }

        public void Validate(string newName)
            => Guard.ForStringLength<InvalidApartmentAdException>(
                newName,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
