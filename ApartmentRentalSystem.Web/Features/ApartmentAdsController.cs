namespace ApartmentRentalSystem.Web.Features
{
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Features.ApartmentAds.Queries.Search;
    using ApartmentRentalSystem.Application.Features.ApartmentAds.Commands.Create;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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
