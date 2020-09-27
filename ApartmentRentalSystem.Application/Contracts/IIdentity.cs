namespace ApartmentRentalSystem.Application.Contracts
{
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Features.Identity;

    public interface IIdentity
    {
        Task<Result> Register(UserInputModel userInput);

        Task<Result<LoginOutputModel>> Login(UserInputModel userInput);
    }
}
