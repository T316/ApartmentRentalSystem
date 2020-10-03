namespace ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Common;
    using ApartmentRentalSystem.Application.Common.Contracts;
    using ApartmentRentalSystem.Application.Rental.Brokers;

    internal static class ChangeApartmentAdCommandExtensions
    {
        public static async Task<Result> BrokerHasApartmentAd(
          this ICurrentUser currentUser,
          IBrokerRepository brokerRepository,
          int apartmentAdId,
          CancellationToken cancellationToken)
        {
            var brokerId = await brokerRepository.GetBrokerId(
                currentUser.UserId,
                cancellationToken);

            var brokerHasApartment = await brokerRepository.HasApartmentAd(
                brokerId,
                apartmentAdId,
                cancellationToken);

            return brokerHasApartment
                ? Result.Success
                : "You cannot edit this apartment ad.";
        }
    }
}
