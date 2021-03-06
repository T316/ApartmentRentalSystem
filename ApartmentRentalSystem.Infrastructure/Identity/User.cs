﻿namespace ApartmentRentalSystem.Infrastructure.Identity
{
    using ApartmentRentalSystem.Application.Identity;
    using ApartmentRentalSystem.Domain.Rental.Exceptions;
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email) => this.Email = email;

        public Broker? Broker { get; private set; }

        public void BecomeBroker(Broker broker)
        {
            if (this.Broker != null)
            {
                throw new InvalidBrokerException($"User '{this.UserName}' is already a broker.");
            }

            this.Broker = broker;
        }
    }
}
