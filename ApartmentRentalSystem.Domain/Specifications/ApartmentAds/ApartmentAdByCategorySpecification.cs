namespace ApartmentRentalSystem.Domain.Specifications.ApartmentAds
{
    using System;
    using System.Linq.Expressions;

    using Models.ApartmentAds;

    public class ApartmentAdByCategorySpecification : Specification<ApartmentAd>
    {
        private readonly int? category;

        public ApartmentAdByCategorySpecification(int? category)
            => this.category = category;

        protected override bool Include => this.category != null;

        public override Expression<Func<ApartmentAd, bool>> ToExpression()
            => apartmentAd => apartmentAd.Category.Id == this.category;
    }
}
