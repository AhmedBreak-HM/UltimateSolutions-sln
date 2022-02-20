using FluentValidation;

namespace UltimateSolutions.Application.Commands.Invoice
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(p => p.CustomerId).NotEmpty().NotNull();
        }
    }
}