namespace ApartmentRentalSystem.Domain.Rental.Models.Brokers
{
    using System.Collections.Generic;
    using System.Linq;

    using ApartmentRentalSystem.Domain.Common.Models;
    using ApartmentRentalSystem.Domain.Rental.Exceptions;
    using ApartmentRentalSystem.Domain.Rental.Models.ApartmentAds;
    using Common;
    using static ModelConstants.Common;

    public class Broker : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<ApartmentAd> apartmentAds;

        internal Broker(string name, string phoneNumber)
        {
            Validate(name);

            Name = name;
            PhoneNumber = phoneNumber;

            apartmentAds = new HashSet<ApartmentAd>();
        }

        private Broker(string name)
        {
            Name = name;
            PhoneNumber = default!;

            apartmentAds = new HashSet<ApartmentAd>();
        }

        public string Name { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Broker UpdateName(string name)
        {
            Validate(name);
            Name = name;

            return this;
        }

        public Broker UpdatePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;

            return this;
        }

        public IReadOnlyCollection<ApartmentAd> ApartmentAds => apartmentAds.ToList().AsReadOnly();

        public void AddApartmentAd(ApartmentAd apartmentAd)
        {
            apartmentAds.Add(apartmentAd);
        }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidBrokerException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(Name));
    }
}
