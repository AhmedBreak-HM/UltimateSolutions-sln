using MediatR;

namespace UltimateSolutions.Application.Commands.User.LogInUser
{
    public class LogInUserCommand : IRequest<LogInUserForReturnDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}