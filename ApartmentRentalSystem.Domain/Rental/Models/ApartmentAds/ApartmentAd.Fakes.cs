namespace ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bogus;
    using FakeItEasy;
    using ApartmentRentalSystem.Domain.Common.Models;

    public class ApartmentAdFakes
    {
        public class ApartmentAdDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(ApartmentAd);

            public object? Create(Type type) => Data.GetApartmentAd();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static IEnumerable<ApartmentAd> GetApartmentAds(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(i => GetApartmentAd(i))
                    .Concat(Enumerable
                        .Range(count + 1, count * 2)
                        .Select(i => GetApartmentAd(i, false)))
                    .ToList();

            public static ApartmentAd GetApartmentAd(int id = 1, bool isAvailable = true)
                => new Faker<ApartmentAd>()
                    .CustomInstantiator(f => new ApartmentAd(
                        new Neighborhood($"Neighborhood{id}"),
                        f.Random.Number(1, 30),
                        A.Dummy<Category>(),
                        f.Image.PicsumUrl(),
                        f.Random.Number(100, 200),
                        A.Dummy<Options>(),
                        isAvailable))
                    .Generate()
                    .SetId(id);
        }
    }
}
