namespace ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Search
{
    using System.Collections.Generic;

    public class SearchApartmentAdsOutputModel
    {
        internal SearchApartmentAdsOutputModel(IEnumerable<ApartmentAdListingModel> apartmentAds, int total)
        {
            ApartmentAds = apartmentAds;
            Total = total;
        }

        public IEnumerable<ApartmentAdListingModel> ApartmentAds { get; }

        public int Total { get; }
    }
}
