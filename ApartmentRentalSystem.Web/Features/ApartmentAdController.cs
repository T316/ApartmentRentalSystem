namespace ApartmentRentalSystem.Web.Features
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using ApartmentRentalSystem.Application.Features.ApartmentAds.Queries.Search;

    [ApiController]
    [Route("[controller]")]
    public class ApartmentAdController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchApartmentAdsOutputModel>> Get(
            [FromQuery] SearchApartmentAdsQuery query)
            => await this.Send(query);
    }
}
