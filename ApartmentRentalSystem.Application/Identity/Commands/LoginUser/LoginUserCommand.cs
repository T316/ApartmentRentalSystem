namespace ApartmentRentalSystem.Application.Identity.Commands.LoginUser
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using ApartmentRentalSystem.Application.Common;
    using ApartmentRentalSystem.Application.Identity.Commands;
    using ApartmentRentalSystem.Application.Identity;

    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        public LoginUserCommand(string email, string password)
            : base(email, password)
        {
        }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;

            public LoginUserCommandHandler(IIdentity identity)
                => this.identity = identity;

            public async Task<Result<LoginOutputModel>> Handle(
                LoginUserCommand request,
                CancellationToken cancellationToken)
                => await identity.Login(request);
        }
    }
}
