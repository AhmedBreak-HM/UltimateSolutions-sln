using FluentValidation;

namespace UltimateSolutions.Application.Commands.User.SignUpUser
{
    public class SignUpUserCommandValidator : AbstractValidator<SignUpUserCommand>
    {
        public SignUpUserCommandValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().NotNull();
            RuleFor(p => p.Password).NotEmpty().NotNull();
        }
    }
}