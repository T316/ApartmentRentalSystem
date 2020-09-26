using System.Reflection;

using ApartmentRentalSystem.Domain.Models.ApartmentAds;
using ApartmentRentalSystem.Domain.Models.Brokers;
using Microsoft.EntityFrameworkCore;

namespace ApartmentRentalSystem.Infrastructure.Persistence
{
    internal class ApartmentRentalDbContext : DbContext
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
