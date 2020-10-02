namespace ApartmentRentalSystem.Domain.Rental.Factories.Brokers
{
    using Models.Brokers;

    internal class BrokerFactory : IBrokerFactory
    {
        private string brokerName = default!;
        private string brokerPhoneNumber = default!;

        public IBrokerFactory WithName(string name)
        {
            brokerName = name;
            return this;
        }

        public IBrokerFactory WithPhoneNumber(string phoneNumber)
        {
            brokerPhoneNumber = phoneNumber;
            return this;
        }

        public Broker Build() => new Broker(brokerName, brokerPhoneNumber);

        public Broker Build(string name, string phoneNumber)
            =>
                WithName(name)
                .WithPhoneNumber(phoneNumber)
                .Build();
    }
}
