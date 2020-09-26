using System.Collections.Generic;
using System.Linq;

using ApartmentRentalSystem.Domain.Models.ApartmentAds;
using ApartmentRentalSystem.Domain.Models.Brokers;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentRentalSystem.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class ApartmentAdController : ControllerBase
    {
        private static readonly Broker Broker = new Broker("Broker", "+123456787");

        public IEnumerable<ApartmentAd> Get() 
            => Broker.ApartmentAds.Where(a => a.IsAvailable);
    }
}
