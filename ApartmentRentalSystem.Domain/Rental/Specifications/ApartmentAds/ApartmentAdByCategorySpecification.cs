namespace ApartmentRentalSystem.Domain.Rental.Specifications.ApartmentAds
{
    using System;
    using System.Linq.Expressions;

    using ApartmentRentalSystem.Domain.Common;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;

    public class ApartmentAdByCategorySpecification : Specification<ApartmentAd>
    {
        private readonly int? category;

        public ApartmentAdByCategorySpecification(int? category)
            => this.category = category;

        protected override bool Include => category != null;

        public override Expression<Func<ApartmentAd, bool>> ToExpression()
            => apartmentAd => apartmentAd.Category.Id == category;
    }
}
