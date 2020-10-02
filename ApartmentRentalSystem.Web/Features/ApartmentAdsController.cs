namespace ApartmentRentalSystem.Web.Features
{
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Features.ApartmentAds.Queries.Search;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Create;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Details;

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

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ApartmentAdDetailsOutputModel>> Details(
            [FromRoute] ApartmentAdDetailsQuery query)
            => await this.Send(query);
    }
}
