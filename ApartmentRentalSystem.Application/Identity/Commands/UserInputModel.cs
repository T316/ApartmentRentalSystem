namespace ApartmentRentalSystem.Application.Identity.Commands
{
    public class UserInputModel
    {
        public UserInputModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }

        public string Password { get; }
    }
}
