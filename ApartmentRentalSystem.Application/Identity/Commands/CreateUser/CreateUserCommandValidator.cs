namespace ApartmentRentalSystem.Application.Identity.Commands.CreateUser
{
    using FluentValidation;

    using static ApartmentRentalSystem.Domain.Rental.Models.ModelConstants.Common;
    using static ApartmentRentalSystem.Domain.Rental.Models.ModelConstants.PhoneNumber;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .MinimumLength(MinEmailLength)
                .MaximumLength(MaxEmailLength)
                .EmailAddress()
                .NotEmpty();

            RuleFor(u => u.Password)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            RuleFor(u => u.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            RuleFor(u => u.PhoneNumber)
                .MinimumLength(MinPhoneNumberLength)
                .MaximumLength(MaxPhoneNumberLength)
                .Matches(PhoneNumberRegularExpression)
                .NotEmpty();
        }
    }
}
