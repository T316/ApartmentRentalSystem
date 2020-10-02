namespace ApartmentRentalSystem.Application.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Common;
    using ApartmentRentalSystem.Application.Identity;
    using ApartmentRentalSystem.Application.Identity.Commands;
    using ApartmentRentalSystem.Application.Rental.Brokers;
    using ApartmentRentalSystem.Domain.Rental.Factories.Brokers;
    using MediatR;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public CreateUserCommand(string email, string password, string name, string phoneNumber)
            : base(email, password)
        {
            Name = name;
            PhoneNumber = phoneNumber;
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
                var result = await identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;

                var broker = brokerFactory
                    .WithName(request.Name)
                    .WithPhoneNumber(request.PhoneNumber)
                    .Build();

                user.BecomeBroker(broker);

                await brokerRepository.Save(broker, cancellationToken);

                return result;
            }
        }
    }
}
