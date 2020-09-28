namespace ApartmentRentalSystem.Application.Features.ApartmentAds.Queries.Search
{
    public class ApartmentAdListingModel
    {
        public ApartmentAdListingModel(
            int id, 
            string neighborhood,
            int floor,
            string imageUrl,
            string category, 
            decimal pricePerMonth)
        {
            this.Id = id;
            this.Neighborhood = neighborhood;
            this.Floor = floor;
            this.ImageUrl = imageUrl;
            this.Category = category;
            this.PricePerMonth = pricePerMonth;
        }

        public int Id { get; }

        public string Neighborhood { get; }

        public int Floor { get; }

        public string ImageUrl { get; }

        public string Category { get; }

        public decimal PricePerMonth { get; }
    }
}
