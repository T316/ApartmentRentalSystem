namespace ApartmentRentalSystem.Application.Features.ApartmentAds.Commands.Create
{
    public class CreateApartmentAdOutputModel
    {
        public CreateApartmentAdOutputModel(int apartmentAdId)
            => this.ApartmentAdId = apartmentAdId;

        public int ApartmentAdId { get; }
    }
}
