namespace ApartmentRentalSystem.Domain.Models.Brokers
{
    using System.Collections.Generic;
    using System.Linq;

    using Bogus;
    using Common;
    using static ApartmentAds.ApartmentAdFakes.Data;

    public class BrokerFakes
    {
        public static class Data
        {
            public static IEnumerable<Broker> GetBrokers(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(GetBroker)
                    .ToList();

            public static Broker GetBroker(int id = 1, int totalApartmentAds = 10)
            {
                var broker = new Faker<Broker>()
                    .CustomInstantiator(f => new Broker(
                        $"Broker{id}",
                        f.Phone.PhoneNumber("+########")))
                    .Generate()
                    .SetId(id);

                foreach (var apartmentAd in GetApartmentAds().Take(totalApartmentAds))
                {
                    broker.AddApartmentAd(apartmentAd);
                }

                return broker;
            }
        }
    }
}
