namespace ApartmentRentalSystem.Infrastructure.Statistics.Configuration
{
    using Domain.Rental.Models.ApartmentAds;
    using Domain.Statistics.Models;
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApartmentAdViewConfiguration : IEntityTypeConfiguration<ApartmentAdView>
    {
        public void Configure(EntityTypeBuilder<ApartmentAdView> builder)
        {
            builder
                .HasKey(cav => cav.Id);

            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<ApartmentAd>()
                .WithMany()
                .HasForeignKey(c => c.ApartmentAdId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
