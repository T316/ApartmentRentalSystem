namespace ApartmentRentalSystem.Infrastructure.Identity.Configurations
{
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(u => u.Broker)
                .WithOne()
                .HasForeignKey<User>("BrokerId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
