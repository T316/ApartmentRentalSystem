namespace ApartmentRentalSystem.Domain.Rental.Specifications.ApartmentAds
{
    using System;
    using System.Linq.Expressions;

    using ApartmentRentalSystem.Domain.Common;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;

    public class ApartmentAdByNeighborhoodSpecification : Specification<ApartmentAd>
    {
        private readonly string? neighborhood;

        public ApartmentAdByNeighborhoodSpecification(string? neighborhood)
            => this.neighborhood = neighborhood;

        protected override bool Include => neighborhood != null;

        public override Expression<Func<ApartmentAd, bool>> ToExpression()
            => apartmentAd => apartmentAd.Neighborhood.Name.ToLower()
                .Contains(neighborhood!.ToLower());
    }
}