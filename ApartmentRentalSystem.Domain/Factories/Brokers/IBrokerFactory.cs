namespace ApartmentRentalSystem.Domain.Factories.Brokers
{
    using Models.Brokers;

    public interface IBrokerFactory : IFactory<Broker>
    {
        IBrokerFactory WithName(string name);

        IBrokerFactory WithPhoneNumber(string phoneNumber);
    }
}
