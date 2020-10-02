namespace ApartmentRentalSystem.Application.Identity
{
    using ApartmentRentalSystem.Domain.Rental.Models.Brokers;

    public interface IUser
    {
        void BecomeBroker(Broker broker);
    }
}
