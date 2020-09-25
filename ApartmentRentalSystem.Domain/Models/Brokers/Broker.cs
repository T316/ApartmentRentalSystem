namespace ApartmentRentalSystem.Domain.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Exceptions;
    using static ModelConstants.Common;

    public class Broker : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<ApartmentAd> apartmentAds;

        internal Broker(string name, string phoneNumber)
        {
            this.Validate(name);

            this.Name = name;
            this.PhoneNumber = phoneNumber;

            this.apartmentAds = new HashSet<ApartmentAd>();
        }

        private Broker(string name)
        {
            this.Name = name;
            this.PhoneNumber = default!;

            this.apartmentAds = new HashSet<ApartmentAd>();
        }

        public string Name { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Broker UpdateName(string name)
        {
            this.Validate(name);
            this.Name = name;

            return this;
        }

        public Broker UpdatePhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }

        public IReadOnlyCollection<ApartmentAd> CarAds => this.apartmentAds.ToList().AsReadOnly();

        public void AddApartmentAd(ApartmentAd carAd)
        {
            this.apartmentAds.Add(carAd);

            //this.AddEvent(new CarAdAddedEvent());
        }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidBrokerException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
