namespace ApartmentRentalSystem.Infrastructure.Common.Persistence
{
    using System.Reflection;

    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;
    using ApartmentRentalSystem.Domain.Statistics.Models;
    using ApartmentRentalSystem.Infrastructure.Identity;
    using ApartmentRentalSystem.Infrastructure.Rental;
    using ApartmentRentalSystem.Infrastructure.Statistics;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    internal class ApartmentRentalDbContext : IdentityDbContext<User>,
        IRentalDbContext,
        IStatisticsDbContext
    {
        public ApartmentRentalDbContext(DbContextOptions<ApartmentRentalDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApartmentAd> ApartmentAds { get; set; } = default!;

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<Neighborhood> Neighborhoods { get; set; } = default!;

        public DbSet<Broker> Brokers { get; set; } = default!;

        public DbSet<Statistics> Statistics { get; set; } = default!;

        public DbSet<ApartmentAdView> ApartmentAdViews { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
