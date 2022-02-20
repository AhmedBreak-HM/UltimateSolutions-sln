using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using UltimateSolutions.Application.Commands.User.LogInUser;
using UltimateSolutions.Application.Commands.User.SignUpUser;
using UltimateSolutions.Application.Queries.User.GetUserByName;

namespace UltimateSolutions.Application.Contracts
{
    public interface IUserRepository
    {
        Task<IdentityResult> SignUp(SignUpUserCommand signUpUserCommand);

        Task<LogInUserForReturnDto> LogIn(LogInUserCommand logInUserCommand, CancellationToken cancellationToken);

        Task<UserForReturnDto> GetUserByName(string name);
    }
}