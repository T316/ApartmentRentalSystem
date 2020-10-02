namespace ApartmentRentalSystem.Application.Brokerships.Brokers.Commands.Edit
{
    using FluentValidation;
    using static Domain.Rental.Models.ModelConstants.Common;
    using static Domain.Rental.Models.ModelConstants.PhoneNumber;

    public class EditBrokerCommandValidator : AbstractValidator<EditBrokerCommand>
    {
        public EditBrokerCommandValidator()
        {
            this.RuleFor(u => u.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.PhoneNumber)
                .MinimumLength(MinPhoneNumberLength)
                .MaximumLength(MaxPhoneNumberLength)
                .Matches(PhoneNumberRegularExpression)
                .NotEmpty();
        }
    }
}
