namespace ApartmentRentalSystem.Domain.Rental.Specifications.ApartmentAds
{
    using System;
    using System.Linq.Expressions;

    using ApartmentRentalSystem.Domain.Common;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;

    public class ApartmentAdByPricePerDaySpecification : Specification<ApartmentAd>
    {
        private readonly decimal minPrice;
        private readonly decimal maxPrice;

        public ApartmentAdByPricePerDaySpecification(
            decimal? minPrice = default,
            decimal? maxPrice = decimal.MaxValue)
        {
            this.minPrice = minPrice ?? default;
            this.maxPrice = maxPrice ?? decimal.MaxValue;
        }

        public override Expression<Func<ApartmentAd, bool>> ToExpression()
            => apartmentAd => minPrice < apartmentAd.PricePerMonth && apartmentAd.PricePerMonth < maxPrice;
    }
}
