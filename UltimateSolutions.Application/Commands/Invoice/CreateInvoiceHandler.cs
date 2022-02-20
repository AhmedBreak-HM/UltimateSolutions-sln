using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UltimateSolutions.Application.Contracts;

namespace UltimateSolutions.Application.Commands.Invoice
{
    public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, int>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public CreateInvoiceHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            CreateInvoiceCommandValidator validations = new CreateInvoiceCommandValidator();
            var result = await validations.ValidateAsync(request, cancellationToken);
            if (result.Errors.Any())
                throw new Exception("Invoice Master is not Valid");

            DetailsForCreateValidator validationsDetails = new DetailsForCreateValidator();
            foreach (var detils in request.InvoiceDetails)
            {
                var resultDetails = await validationsDetails.ValidateAsync(detils, cancellationToken);
                if (resultDetails.Errors.Any())
                    throw new Exception("Invoice Details is not Valid");
            }
            return await _invoiceRepository.CreateInvoice(request);
        }
    }
}