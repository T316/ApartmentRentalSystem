namespace ApartmentRentalSystem.Domain.Factories.Brokers
{
    using Models.Brokers;

    internal class BrokerFactory : IBrokerFactory
    {
        private string brokerName = default!;
        private string brokerPhoneNumber = default!;

        public IBrokerFactory WithName(string name)
        {
            this.brokerName = name;
            return this;
        }

        public IBrokerFactory WithPhoneNumber(string phoneNumber)
        {
            this.brokerPhoneNumber = phoneNumber;
            return this;
        }

        public Broker Build() => new Broker(this.brokerName, this.brokerPhoneNumber);

        public Broker Build(string name, string phoneNumber)
            => this
                .WithName(name)
                .WithPhoneNumber(phoneNumber)
                .Build();
    }
}
