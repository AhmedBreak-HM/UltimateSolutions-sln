using MediatR;
using Microsoft.AspNetCore.Identity;

namespace UltimateSolutions.Application.Commands.User.SignUpUser
{
    public class SignUpUserCommand : IRequest<IdentityResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}