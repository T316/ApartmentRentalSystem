namespace ApartmentRentalSystem.Application.Brokerships.ApartmentAds.Commands.Edit
{
    using ApartmentRentalSystem.Application.Rental.ApartmentAds;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Common;
    using FluentValidation;

    public class EditApartmentAdCommandValidator : AbstractValidator<EditApartmentAdCommand>
    {
        public EditApartmentAdCommandValidator(IApartmentAdRepository apartmentAdRepository)
            => this.Include(new ApartmentAdCommandValidator<EditApartmentAdCommand>(apartmentAdRepository));
    }
}
