namespace ApartmentRentalSystem.Domain.Specifications.ApartmentAds
{
    using System;
    using System.Linq.Expressions;
    using Models.ApartmentAds;

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
            => apartmentAd => this.minPrice < apartmentAd.PricePerMonth && apartmentAd.PricePerMonth < this.maxPrice;
    }
}
