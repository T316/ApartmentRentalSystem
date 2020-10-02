namespace ApartmentRentalSystem.Application.Identity
{
    using System.Threading.Tasks;

    using ApartmentRentalSystem.Application.Common;
    using ApartmentRentalSystem.Application.Identity.Commands;
    using ApartmentRentalSystem.Application.Identity.Commands.LoginUser;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginOutputModel>> Login(UserInputModel userInput);
    }
}
