﻿namespace ApartmentRentalSystem.Domain.Common
{
    using Models.ApartmentAds;
    using FluentAssertions;
    using Xunit;

    public class ValueObjectSpecs
    {
        [Fact]
        public void ValueObjectsWithEqualPropertiesShouldBeEqual()
        {
            // Arrange
            var first = new Options(true, true, HheatingType.Fireplace);
            var second = new Options(true, true, HheatingType.Fireplace);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
        {
            // Arrange
            var first = new Options(true, true, HheatingType.Еlectricity);
            var second = new Options(true, true, HheatingType.Fireplace);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }
}