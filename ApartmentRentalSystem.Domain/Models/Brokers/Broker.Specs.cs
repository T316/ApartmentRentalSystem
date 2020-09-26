namespace ApartmentRentalSystem.Domain.Models.Brokers
{
    using ApartmentAds;
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class DealerSpecs
    {
        [Fact]
        public void AddCarAdShouldSaveCarAd()
        {
            // Arrange
            var broker = new Broker("Valid broker", "+12345678");
            var apartmentAd = A.Dummy<ApartmentAd>();

            // Act
            broker.AddApartmentAd(apartmentAd);

            // Assert
            broker.ApartmentAds.Should().Contain(apartmentAd);
        }
    }
}
