namespace ApartmentRentalSystem.Application.Features.Identity
{
    using ApartmentRentalSystem.Domain.Models.Brokers;

    public interface IUser
    {
        void BecomeBroker(Broker broker);
    }
}
