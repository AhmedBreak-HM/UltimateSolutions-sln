using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UltimateSolutions.Application.Contracts;

namespace UltimateSolutions.Application.Commands.User.LogInUser
{
    public class LogInUserCommandHandler : IRequestHandler<LogInUserCommand, LogInUserForReturnDto>
    {
        private readonly IUserRepository _userRepository;

        public LogInUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LogInUserForReturnDto> Handle(LogInUserCommand request, CancellationToken cancellationToken)
        {
            LogInUserCommandValidator validations = new LogInUserCommandValidator();
            var result = await validations.ValidateAsync(request, cancellationToken);
            if (result.Errors.Any())
                throw new Exception("LogIn is not Valid");
            return await _userRepository.LogIn(request, cancellationToken);
        }
    }
}