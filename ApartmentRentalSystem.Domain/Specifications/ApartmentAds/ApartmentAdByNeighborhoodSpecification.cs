namespace ApartmentRentalSystem.Domain.Specifications.ApartmentAds
{
    using System;
    using System.Linq.Expressions;

    using Models.ApartmentAds;

    public class ApartmentAdByNeighborhoodSpecification : Specification<ApartmentAd>
    {
        private readonly string? neighborhood;

        public ApartmentAdByNeighborhoodSpecification(string? neighborhood)
            => this.neighborhood = neighborhood;

        protected override bool Include => this.neighborhood != null;

        public override Expression<Func<ApartmentAd, bool>> ToExpression()
            => apartmentAd => apartmentAd.Neighborhood.Name.ToLower()
                .Contains(this.neighborhood!.ToLower());
    }
}