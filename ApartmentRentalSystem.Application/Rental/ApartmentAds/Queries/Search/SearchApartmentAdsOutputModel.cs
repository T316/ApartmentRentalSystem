namespace ApartmentRentalSystem.Application.Features.ApartmentAds.Queries.Search
{
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Search;
    using System.Collections.Generic;

    public class SearchApartmentAdsOutputModel
    {
        internal SearchApartmentAdsOutputModel(IEnumerable<ApartmentAdListingModel> apartmentAds, int total)
        {
            this.ApartmentAds = apartmentAds;
            this.Total = total;
        }

        public IEnumerable<ApartmentAdListingModel> ApartmentAds { get; }

        public int Total { get; }
    }
}
