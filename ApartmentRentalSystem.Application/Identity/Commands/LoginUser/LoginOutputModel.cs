namespace ApartmentRentalSystem.Application.Identity.Commands.LoginUser
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token)
            => Token = token;

        public string Token { get; }
    }
}
