namespace ApartmentRentalSystem.Infrastructure.Common.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using ApartmentRentalSystem.Domain.Common;
    using Microsoft.EntityFrameworkCore;

    internal class ApartmentRentalDbInitializer : IInitializer
    {
        private readonly ApartmentRentalDbContext db;
        private readonly IEnumerable<IInitialData> initialDataProviders;

        public ApartmentRentalDbInitializer(
            ApartmentRentalDbContext db,
            IEnumerable<IInitialData> initialDataProviders)
        {
            this.db = db;
            this.initialDataProviders = initialDataProviders;
        }

        public void Initialize()
        {
            db.Database.Migrate();

            foreach (var initialDataProvider in initialDataProviders)
            {
                if (DataSetIsEmpty(initialDataProvider.EntityType))
                {
                    var data = initialDataProvider.GetData();

                    foreach (var entity in data)
                    {
                        db.Add(entity);
                    }
                }
            }

            db.SaveChanges();
        }

        private bool DataSetIsEmpty(Type type)
        {
            var setMethod = GetType()
                .GetMethod(nameof(this.GetSet), BindingFlags.Instance | BindingFlags.NonPublic)!
                .MakeGenericMethod(type);

            var set = setMethod.Invoke(this, Array.Empty<object>());

            var countMethod = typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == nameof(Queryable.Count) && m.GetParameters().Length == 1)
                .MakeGenericMethod(type);

            var result = (int)countMethod.Invoke(null, new[] { set })!;

            return result == 0;
        }

        private DbSet<TEntity> GetSet<TEntity>()
            where TEntity : class
            => db.Set<TEntity>();
    }
}
