namespace ApartmentRentalSystem.Web.Features
{
    using System.Collections.Generic;
    using System.Linq;

    using ApartmentRentalSystem.Application.Contracts;
    using ApartmentRentalSystem.Domain.Models.ApartmentAds;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ApartmentAdController : ControllerBase
    {
        private readonly IRepository<ApartmentAd> apartmentAd;

        public ApartmentAdController(IRepository<ApartmentAd> apartmentAd)
            => this.apartmentAd = apartmentAd;

        [HttpGet]
        public IEnumerable<ApartmentAd> Get() => this.apartmentAd
            .All()
            .Where(a => a.IsAvailable);
    }
}
