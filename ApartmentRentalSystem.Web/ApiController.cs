namespace ApartmentRentalSystem.Web
{
    using System.Threading.Tasks;

    using MediatR;
    using ApartmentRentalSystem.Web.Common;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using ApartmentRentalSystem.Application.Common;

    public abstract class ApiController : ControllerBase
    {
        public const string PathSeparator = "/";
        public const string Id = "{id}";

        private IMediator? mediator;

        protected IMediator Mediator
            => this.mediator ??= this.HttpContext
            .RequestServices
            .GetService<IMediator>();

        protected Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
            => this.Mediator.Send(request).ToActionResult();

        protected Task<ActionResult> Send(IRequest<Result> request)
            => this.Mediator.Send(request).ToActionResult();

        protected Task<ActionResult<TResult>> Send<TResult>(IRequest<Result<TResult>> request)
            => this.Mediator.Send(request).ToActionResult();
    }
}
