namespace ApartmentRentalSystem.Web.Features
{
    using System.Linq;

    using ApartmentRentalSystem.Application;
    using ApartmentRentalSystem.Application.Contracts;
    using ApartmentRentalSystem.Domain.Models.ApartmentAds;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    [ApiController]
    [Route("[controller]")]
    public class ApartmentAdController : ControllerBase
    {
        private readonly IRepository<ApartmentAd> apartmentAd;
        private readonly IOptions<ApplicationSettings> settings;

        public ApartmentAdController(
            IRepository<ApartmentAd> apartmentAd,
            IOptions<ApplicationSettings> settings)
        {
            this.apartmentAd = apartmentAd;
            this.settings = settings;
        }

        [HttpGet]
        public object Get() => new
        {
            Settings = this.settings,
            ApartmentAds = this.apartmentAd
                .All()
                .Where(a => a.IsAvailable)
                .ToList()
        };
    }
}
