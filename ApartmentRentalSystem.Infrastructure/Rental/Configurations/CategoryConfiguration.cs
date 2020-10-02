namespace ApartmentRentalSystem.Infrastructure.Rental.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static ApartmentRentalSystem.Domain.Rental.Models.ModelConstants.Common;
    using static ApartmentRentalSystem.Domain.Rental.Models.ModelConstants.Category;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;

    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);
        }
    }
}
