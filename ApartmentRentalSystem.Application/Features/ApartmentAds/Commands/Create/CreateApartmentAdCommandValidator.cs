namespace ApartmentRentalSystem.Application.Features.ApartmentAds.Commands.Create
{
    using System;
    using Domain.Common;
    using Domain.Models.ApartmentAds;
    using FluentValidation;

    public class CreateApartmentAdCommandValidator : AbstractValidator<CreateApartmentAdCommand>
    {
        public CreateApartmentAdCommandValidator(IApartmentAdRepository apartmentAdRepository)
        {
            this.RuleFor(a => a.Category)
                .MustAsync(async (category, token) => await apartmentAdRepository
                    .GetCategory(category, token) != null)
                .WithMessage("'{PropertyName}' does not exist.");

            this.RuleFor(a => a.ImageUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                .WithMessage("'{PropertyName}' must be a valid url.")
                .NotEmpty();

            this.RuleFor(a => a.HeatingType)
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
