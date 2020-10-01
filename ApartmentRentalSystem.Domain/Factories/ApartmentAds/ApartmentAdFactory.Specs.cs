namespace ApartmentRentalSystem.Domain.Factories.ApartmentAds
{
    using System;
    using Exceptions;
    using FluentAssertions;
    using Models.ApartmentAds;
    using Xunit;

    public class apartmentAdFactorySpecs
    {
        [Fact]
        public void BuildShouldThrowExceptionIfNeighborhoodIsNotSet()
        {
            // Assert
            var apartmentAdFactory = new ApartmentAdFactory();

            // Act
            Action act = () => apartmentAdFactory
                .WithCategory("TestCategory", "TestDescription")
                .WithOptions(true, true, HeatingType.Еlectricity)
                .Build();

            // Assert
            act.Should().Throw<InvalidApartmentAdException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfCategoryIsNotSet()
        {
            // Assert
            var apartmentAdFactory = new ApartmentAdFactory();

            // Act
            Action act = () => apartmentAdFactory
                .WithNeighborhood("TestNeighborhood")
                .WithOptions(true, true, HeatingType.Еlectricity)
                .Build();

            // Assert
            act.Should().Throw<InvalidApartmentAdException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfOptionsAreNotSet()
        {
            // Assert
            var apartmentAdFactory = new ApartmentAdFactory();

            // Act
            Action act = () => apartmentAdFactory
                .WithNeighborhood("TestNeighborhood")
                .WithCategory("TestCategory", "TestDescription")
                .Build();

            // Assert
            act.Should().Throw<InvalidApartmentAdException>();
        }

        [Fact]
        public void BuildShouldCreateApartmentAdIfEveryPropertyIsSet()
        {
            // Assert
            var apartmentAdFactory = new ApartmentAdFactory();

            // Act
            var apartmentAd = apartmentAdFactory
                .WithNeighborhood("TestNeighborhood")
                .WithCategory(CategoryFakes.ValidCategoryName, "TestCategoryDescription")
                .WithOptions(true, true, HeatingType.Еlectricity)
                .WithImageUrl("http://test.image.url")
                .WithFloor(10)
                .WithPricePerMonth(1000)
                .Build();

            // Assert
            apartmentAd.Should().NotBeNull();
        }
    }
}
