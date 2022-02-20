using FluentValidation;

namespace UltimateSolutions.Application.Commands.Invoice
{
    public class DetailsForCreateValidator : AbstractValidator<DetailsForCreateDto>
    {
        public DetailsForCreateValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty().NotNull();
        }
    }
}