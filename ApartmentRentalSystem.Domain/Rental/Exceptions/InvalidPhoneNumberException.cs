namespace ApartmentRentalSystem.Domain.Rental.Exceptions
{
    using ApartmentRentalSystem.Domain.Common;

    public class InvalidPhoneNumberException : BaseDomainException
    {
        public InvalidPhoneNumberException()
        {
        }

        public InvalidPhoneNumberException(string error) => Error = error;
    }
}
