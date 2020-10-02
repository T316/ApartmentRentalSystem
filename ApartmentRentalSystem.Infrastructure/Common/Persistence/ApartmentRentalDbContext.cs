namespace ApartmentRentalSystem.Infrastructure.Common.Persistence
{
    using System.Reflection;

    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;
    using ApartmentRentalSystem.Infrastructure.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    internal class ApartmentRentalDbContext : IdentityDbContext<User>
    {
        public ApartmentRentalDbContext(DbContextOptions<ApartmentRentalDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApartmentAd> ApartmentAds { get; set; } = default!;

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<Neighborhood> Neighborhoods { get; set; } = default!;

        public DbSet<Broker> Brokers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
