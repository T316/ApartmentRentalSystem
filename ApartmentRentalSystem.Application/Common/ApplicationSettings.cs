namespace ApartmentRentalSystem.Application.Common
{
    public class ApplicationSettings
    {
        public ApplicationSettings()
            => Secret = default!;

        public string Secret { get; private set; }
    }
}
