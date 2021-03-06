﻿namespace ApartmentRentalSystem.Infrastructure.Rental.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static ApartmentRentalSystem.Domain.Rental.Models.ModelConstants.Common;
    using static ApartmentRentalSystem.Domain.Rental.Models.ModelConstants.ApartmentAd;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;

    internal class ApartmentAdConfiguration : IEntityTypeConfiguration<ApartmentAd>
    {
        public void Configure(EntityTypeBuilder<ApartmentAd> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Floor)
                .IsRequired()
                .HasMaxLength(MaxFloor);

            builder
                .Property(a => a.ImageUrl)
                .IsRequired()
                .HasMaxLength(MaxUrlLength);

            builder
                .Property(a => a.PricePerMonth)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(a => a.IsAvailable)
                .IsRequired();

            builder
                .HasOne(a => a.Neighborhood)
                .WithMany()
                .HasForeignKey("NeighborhoodId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Category)
                .WithMany()
                .HasForeignKey("CategoryId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .OwnsOne(c => c.Options, o =>
                {
                    o.WithOwner();

                    o.Property(op => op.HasParking);
                    o.Property(op => op.HasBasement);

                    o.OwnsOne(
                        op => op.HeatingType,
                        h =>
                        {
                            h.WithOwner();

                            h.Property(ht => ht.Value);
                        });
                });
        }
    }
}
