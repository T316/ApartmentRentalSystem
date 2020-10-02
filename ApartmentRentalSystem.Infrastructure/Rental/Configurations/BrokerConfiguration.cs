namespace ApartmentRentalSystem.Infrastructure.Rental.Configurations
{
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static ApartmentRentalSystem.Domain.Rental.Models.ModelConstants.Common;

    internal class BrokerConfiguration : IEntityTypeConfiguration<Broker>
    {
        public void Configure(EntityTypeBuilder<Broker> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .OwnsOne(
                    b => b.PhoneNumber,
                    p =>
                    {
                        p.WithOwner();

                        p.Property(pn => pn.Number);
                    });

            builder
                .HasMany(b => b.ApartmentAds)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("apartmentAds");
        }
    }
}
