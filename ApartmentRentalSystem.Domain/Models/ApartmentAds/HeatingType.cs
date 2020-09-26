namespace ApartmentRentalSystem.Domain.Models.ApartmentAds
{
    using Common;

    public class HheatingType : Enumeration
    {
        public static readonly HheatingType Еlectricity = new HheatingType(1, nameof(Еlectricity));
        public static readonly HheatingType Fireplace = new HheatingType(2, nameof(Fireplace));

        private HheatingType(int value)
            : this(value, FromValue<HheatingType>(value).Name)
        {
        }

        private HheatingType(int value, string name) 
            : base(value, name)
        {
        }
    }
}
