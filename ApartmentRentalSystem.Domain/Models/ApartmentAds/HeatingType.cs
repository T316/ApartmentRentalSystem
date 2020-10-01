namespace ApartmentRentalSystem.Domain.Models.ApartmentAds
{
    using Common;

    public class HeatingType : Enumeration
    {
        public static readonly HeatingType Еlectricity = new HeatingType(1, nameof(Еlectricity));
        public static readonly HeatingType Fireplace = new HeatingType(2, nameof(Fireplace));

        private HeatingType(int value)
            : this(value, FromValue<HeatingType>(value).Name)
        {
        }

        private HeatingType(int value, string name) 
            : base(value, name)
        {
        }
    }
}
