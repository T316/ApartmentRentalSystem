namespace ApartmentRentalSystem.Domain
{
    using ApartmentRentalSystem.Domain.Rental.Factories.ApartmentAds;
    using ApartmentRentalSystem.Domain.Rental.Factories.Brokers;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class DomainConfigurationSpecs
    {
        [Fact]
        public void AddDomainShouldRegisterFactories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IBrokerFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<IApartmentAdFactory>()
                .Should()
                .NotBeNull();
        }
    }
}
