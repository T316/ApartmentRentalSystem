﻿namespace ApartmentRentalSystem.Domain.Common.Models
{
    using FluentAssertions;
    using Xunit;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;

    public class EntitySpecs
    {
        [Fact]
        public void EntitiesWithEqualIdsShouldBeEqual()
        {
            // Arrange
            var first = new Neighborhood("First").SetId(1);
            var second = new Neighborhood("Second").SetId(1);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void EntitiesWithDifferentIdsShouldNotBeEqual()
        {
            // Arrange
            var first = new Neighborhood("First").SetId(1);
            var second = new Neighborhood("Second").SetId(2);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }

    internal static class EntityExtensions
    {
        public static TEntity SetId<TEntity>(this TEntity entity, int id)
            where TEntity : Entity<int>
            => (entity.SetId<int>(id) as TEntity)!;

        private static Entity<T> SetId<T>(this Entity<T> entity, int id)
            where T : struct
        {
            entity
                .GetType()
                .BaseType!
                .GetProperty(nameof(Entity<T>.Id))!
                .GetSetMethod(true)!
                .Invoke(entity, new object[] { id });

            return entity;
        }
    }
}
