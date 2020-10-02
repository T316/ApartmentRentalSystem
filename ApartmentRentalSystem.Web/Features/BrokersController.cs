namespace ApartmentRentalSystem.Web.Features
{
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Brokerships.Brokers.Commands.Edit;
    using ApartmentRentalSystem.Application.Brokerships.Brokers.Queries.Details;
    using Application.Common;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class BrokersController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<BrokerDetailsOutputModel>> Details(
            [FromRoute] BrokerDetailsQuery query)
            => await this.Send(query);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditBrokerCommand command)
            => await this.Send(command.SetId(id));
    }
}
