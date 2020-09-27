﻿namespace ApartmentRentalSystem.Domain.Models.Brokers
{
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Exceptions;
    using Models.ApartmentAds;
    using static ModelConstants.Common;

    public class Broker : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<ApartmentAd> apartmentAds;

        public Broker(string name, string phoneNumber)
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

        public IReadOnlyCollection<ApartmentAd> ApartmentAds => this.apartmentAds.ToList().AsReadOnly();

        public void AddApartmentAd(ApartmentAd apartmentAd)
        {
            this.apartmentAds.Add(apartmentAd);
        }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidBrokerException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
