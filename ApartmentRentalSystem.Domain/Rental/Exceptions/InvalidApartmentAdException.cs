namespace ApartmentRentalSystem.Domain.Rental.Exceptions
{
    using ApartmentRentalSystem.Domain.Common;

    public class InvalidApartmentAdException : BaseDomainException
    {
        public InvalidApartmentAdException()
        {
        }

        public InvalidApartmentAdException(string error) => Error = error;
    }
}