namespace ApartmentRentalSystem.Application.Features.Identity.Commands.CreateUser
{
    using Bogus;

    public class CreateUserCommandFakes
    {
        public static class Data
        {
            public static CreateUserCommand GetCommand()
                => new Faker<CreateUserCommand>()
                    .CustomInstantiator(f => new CreateUserCommand(
                        f.Internet.Email(),
                        f.Lorem.Letter(10),
                        f.Name.FullName(),
                        f.Phone.PhoneNumber("+#######")))
                    .Generate();
        }
    }
}
