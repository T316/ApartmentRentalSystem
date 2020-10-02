namespace ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Create
{
    public class CreateApartmentAdOutputModel
    {
        public CreateApartmentAdOutputModel(int apartmentAdId)
            => ApartmentAdId = apartmentAdId;

        public int ApartmentAdId { get; }
    }
}
