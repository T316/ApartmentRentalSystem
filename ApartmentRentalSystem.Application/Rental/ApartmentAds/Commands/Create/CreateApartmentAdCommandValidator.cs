namespace ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Create
{
    using System;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds;
    using ApartmentRentalSystem.Domain.Common.Models;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using FluentValidation;

    public class CreateApartmentAdCommandValidator : AbstractValidator<CreateApartmentAdCommand>
    {
        public CreateApartmentAdCommandValidator(IApartmentAdRepository apartmentAdRepository)
        {
            RuleFor(a => a.Category)
                .MustAsync(async (category, token) => await apartmentAdRepository
                    .GetCategory(category, token) != null)
                .WithMessage("'{PropertyName}' does not exist.");

            RuleFor(a => a.ImageUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                .WithMessage("'{PropertyName}' must be a valid url.")
                .NotEmpty();

            RuleFor(a => a.HeatingType)
                .Must(BeAValidHeatingType)
                .WithMessage("'{PropertyName}' is not a valid heating type.");
        }

        private static bool BeAValidHeatingType(int heatingType)
        {
            try
            {
                Enumeration.FromValue<HeatingType>(heatingType);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
