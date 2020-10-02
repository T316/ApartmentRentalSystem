namespace ApartmentRentalSystem.Domain.Rental.Exceptions
{
    using ApartmentRentalSystem.Domain.Common;

    public class InvalidOptionsException : BaseDomainException
    {
        public InvalidOptionsException()
        {
        }

        public InvalidOptionsException(string error) => Error = error;
    }
}
