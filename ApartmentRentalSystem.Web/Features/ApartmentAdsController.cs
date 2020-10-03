namespace ApartmentRentalSystem.Web.Features
{
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Features.ApartmentAds.Queries.Search;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Commands.Create;
    using ApartmentRentalSystem.Application.Rental.ApartmentAds.Queries.Details;
    using ApartmentRentalSystem.Application.Brokerships.ApartmentAds.Commands.ChangeAvailability;
    using ApartmentRentalSystem.Application.Brokerships.ApartmentAds.Commands.Delete;
    using ApartmentRentalSystem.Application.Brokerships.ApartmentAds.Commands.Edit;
    using ApartmentRentalSystem.Application.Common;

    [ApiController]
    [Route("[controller]")]
    public class ApartmentAdsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchApartmentAdsOutputModel>> Search(
            [FromQuery] SearchApartmentAdsQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ApartmentAdDetailsOutputModel>> Details(
            [FromRoute] ApartmentAdDetailsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateApartmentAdOutputModel>> Create(
            CreateApartmentAdCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditApartmentAdCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteApartmentAdCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id + PathSeparator + nameof(ChangeAvailability))]
        public async Task<ActionResult> ChangeAvailability(
            [FromRoute] ChangeAvailabilityCommand query)
            => await this.Send(query);
    }
}
