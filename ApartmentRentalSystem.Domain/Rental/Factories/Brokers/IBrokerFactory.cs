namespace ApartmentRentalSystem.Domain.Rental.Factories.Brokers
{
    using ApartmentRentalSystem.Domain.Common;
    using Models.Brokers;

    public interface IBrokerFactory : IFactory<Broker>
    {
        IBrokerFactory WithName(string name);

        IBrokerFactory WithPhoneNumber(string phoneNumber);
    }
}
