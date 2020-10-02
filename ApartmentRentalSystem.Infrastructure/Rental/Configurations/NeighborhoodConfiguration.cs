namespace ApartmentRentalSystem.Infrastructure.Rental.Configurations
{
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static ApartmentRentalSystem.Domain.Rental.Models.ModelConstants.Common;

    internal class NeighborhoodConfiguration : IEntityTypeConfiguration<Neighborhood>
    {
        public void Configure(EntityTypeBuilder<Neighborhood> builder)
        {
            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);
        }
    }
}
