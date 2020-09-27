namespace ApartmentRentalSystem.Infrastructure.Persistence
{
    using ApartmentRentalSystem.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;

    internal class ApartmentRentalDbInitializer : IInitializer
    {
        private readonly ApartmentRentalDbContext db;

        public ApartmentRentalDbInitializer(ApartmentRentalDbContext db) => this.db = db;

        public void Initialize() => this.db.Database.Migrate();
    }
}
