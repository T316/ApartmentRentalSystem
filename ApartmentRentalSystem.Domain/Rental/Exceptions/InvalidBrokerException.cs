namespace ApartmentRentalSystem.Domain.Rental.Exceptions
{
    using ApartmentRentalSystem.Domain.Common;

    public class InvalidBrokerException : BaseDomainException
    {
        public InvalidBrokerException()
        {
        }

        public InvalidBrokerException(string error) => Error = error;
    }
}
