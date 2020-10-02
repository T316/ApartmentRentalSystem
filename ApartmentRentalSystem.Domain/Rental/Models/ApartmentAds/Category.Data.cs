namespace ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds
{
    using System;
    using System.Collections.Generic;

    using Common;

    internal class CategoryData : IInitialData
    {
        public Type EntityType => typeof(Category);

        public IEnumerable<object> GetData()
            => new List<Category>
            {
                new Category("One-room apartment", "A one-room apartment is an apartment with one room and bathroom."),
                new Category("Two-room apartment", "A two-room apartment is an apartment with two room and bathroom."),
                new Category("Three-room apartment", "A three-room apartment is an apartment with three room and bathroom."),
                new Category("Penthouse", "A penthouse is an apartment or unit on the highest floor of an apartment building. Penthouses are typically differentiated from other apartments by luxury features."),
            };
    }
}
