namespace ApartmentRentalSystem.Application.Brokerships.Brokers.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Rental.Brokers;
    using Common;
    using Common.Contracts;
    using MediatR;

    public class EditBrokerCommand : EntityCommand<int>, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class EditBrokerCommandHandler : IRequestHandler<EditBrokerCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IBrokerRepository brokerRepository;

            public EditBrokerCommandHandler(
                ICurrentUser currentUser,
                IBrokerRepository brokerRepository)
            {
                this.currentUser = currentUser;
                this.brokerRepository = brokerRepository;
            }

            public async Task<Result> Handle(
                EditBrokerCommand request, 
                CancellationToken cancellationToken)
            {
                var broker = await this.brokerRepository.FindByUser(
                    this.currentUser.UserId, 
                    cancellationToken);

                if (request.Id != broker.Id)
                {
                    return "You cannot edit this broker.";
                }

                broker
                    .UpdateName(request.Name)
                    .UpdatePhoneNumber(request.PhoneNumber);

                await this.brokerRepository.Save(broker, cancellationToken);

                return Result.Success;
            }
        }
    }
}
