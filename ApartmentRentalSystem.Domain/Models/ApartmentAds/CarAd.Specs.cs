namespace ApartmentRentalSystem.Domain.Models.ApartmentAds
{
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class CarAdSpecs
    {
        [Fact]
        public void ChangeAvailabilityShouldMutateIsAvailable()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();

            // Act
            apartmentAd.ChangeAvailability();

            // Assert
            apartmentAd.IsAvailable.Should().BeFalse();
        }
    }
}
