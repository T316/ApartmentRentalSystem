namespace ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Common
{
    using System;
    using Application.Common;
    using Domain.Common.Models;

    using FluentValidation;
    using static Domain.Rental.Models.ModelConstants.Common;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;

    public class ApartmentAdCommandValidator<TCommand> : AbstractValidator<ApartmentAdCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public ApartmentAdCommandValidator(IApartmentAdRepository apartmentAdRepository)
        {
            this.RuleFor(c => c.Neighborhood)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(c => c.Category)
                .MustAsync(async (category, token) => await apartmentAdRepository
                    .GetCategory(category, token) != null)
                .WithMessage("'{PropertyName}' does not exist.");

            this.RuleFor(c => c.ImageUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("'{PropertyName}' must be a valid url.")
                .NotEmpty();

            this.RuleFor(c => c.PricePerMonth)
                .InclusiveBetween(Zero, decimal.MaxValue);

            this.RuleFor(c => c.HeatingType)
                .Must(Enumeration.HasValue<HeatingType>)
                .WithMessage("'Heating Type' is not valid.");
        }
    }
}
