namespace ApartmentRentalSystem.Web.Features
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Create;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Search;

    [ApiController]
    [Route("[controller]")]
    public class ApartmentAdsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchApartmentAdsOutputModel>> Search(
            [FromQuery] SearchApartmentAdsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateApartmentAdOutputModel>> Create(
            CreateApartmentAdCommand command)
            => await this.Send(command);
    }
}
