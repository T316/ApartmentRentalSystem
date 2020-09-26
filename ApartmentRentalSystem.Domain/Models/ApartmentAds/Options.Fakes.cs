namespace ApartmentRentalSystem.Domain.Models.ApartmentAds
{
    using System;
    using FakeItEasy;

    public class OptionsFakes
    {
        public class OptionsDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Options);

            public object? Create(Type type)
                => new Options(true, true, HheatingType.Еlectricity);

            public Priority Priority => Priority.Default;
        }
    }
}
