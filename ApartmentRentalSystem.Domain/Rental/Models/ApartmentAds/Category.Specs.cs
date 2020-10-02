namespace ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds
{
    using System;

    using ApartmentRentalSystem.Domain.Rental.Exceptions;
    using FluentAssertions;
    using Xunit;

    public class CategorySpecs
    {
        [Fact]
        public void ValidCategoryShouldNotThrowException()
        {
            // Act
            Action act = () => new Category("Valid name", "Valid description text");

            // Assert
            act.Should().NotThrow<InvalidApartmentAdException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            // Act
            Action act = () => new Category("", "Valid description text");

            // Assert
            act.Should().Throw<InvalidApartmentAdException>();
        }
    }
}
