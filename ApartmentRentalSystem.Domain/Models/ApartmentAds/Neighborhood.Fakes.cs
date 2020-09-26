namespace ApartmentRentalSystem.Domain.Models.ApartmentAds
{
    using System;
    using FakeItEasy;

    public class NeighborhoodFakes
    {
        public class NeighborhoodDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Neighborhood);

            public object? Create(Type type)
                => new Neighborhood("Valid manufacturer");

            public Priority Priority => Priority.Default;
        }
    }
}
