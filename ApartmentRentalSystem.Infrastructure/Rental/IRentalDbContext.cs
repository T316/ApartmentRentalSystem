namespace ApartmentRentalSystem.Infrastructure.Rental
{
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;
    using ApartmentRentalSystem.Infrastructure.Common.Persistence;
    using ApartmentRentalSystem.Infrastructure.Identity;
    using Microsoft.EntityFrameworkCore;

    public interface IRentalDbContext : IDbContext
    {
        DbSet<ApartmentAd> ApartmentAds { get; }

        DbSet<Category> Categories { get; }

        DbSet<Neighborhood> Neighborhoods { get; }

        DbSet<Broker> Brokers { get; }

        DbSet<User> Users { get; } // TODO: Temporary workaround
    }
}
