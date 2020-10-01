namespace ApartmentRentalSystem.Application.Features.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using ApartmentRentalSystem.Application.Features.Brokers;
    using ApartmentRentalSystem.Domain.Factories.Brokers;
    using MediatR;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public CreateUserCommand(string email, string password, string name, string phoneNumber)
            : base(email, password)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; }

        public string PhoneNumber { get; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly IBrokerFactory brokerFactory;
            private readonly IBrokerRepository brokerRepository;

            public CreateUserCommandHandler(
                IIdentity identity,
                IBrokerFactory brokerFactory,
                IBrokerRepository brokerRepository)
            {
                this.identity = identity;
                this.brokerFactory = brokerFactory;
                this.brokerRepository = brokerRepository;
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;

                var broker = this.brokerFactory
                    .WithName(request.Name)
                    .WithPhoneNumber(request.PhoneNumber)
                    .Build();

                user.BecomeBroker(broker);

                await this.brokerRepository.Save(broker, cancellationToken);

                return result;
            }
        }
    }
}
