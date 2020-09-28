namespace ApartmentRentalSystem.Web.Features
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Application.Features.Identity;
    using ApartmentRentalSystem.Application.Features.Identity.Commands.LoginUser;
    using ApartmentRentalSystem.Web.Common;
    using ApartmentRentalSystem.Application.Features.Identity.Commands.CreateUser;

    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ApiController
    {
        private readonly IIdentity identity;

        public IdentityController(IIdentity identity) => this.identity = identity;

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(CreateUserCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand command)
            => await this.Send(command);
    }
}
