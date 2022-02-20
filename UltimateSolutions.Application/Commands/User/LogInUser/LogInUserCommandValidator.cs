using FluentValidation;

namespace UltimateSolutions.Application.Commands.User.LogInUser
{
    public class LogInUserCommandValidator : AbstractValidator<LogInUserCommand>
    {
        public LogInUserCommandValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().NotNull();
            RuleFor(p => p.Password).NotEmpty().NotNull();
        }
    }
}