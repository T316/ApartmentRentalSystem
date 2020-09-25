namespace ApartmentRentalSystem.Domain.Exceptions
{

    public class InvalidBrokerException : BaseDomainException
    {
        public InvalidBrokerException()
        {
        }

        public InvalidBrokerException(string error) => this.Error = error;
    }
}
