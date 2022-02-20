using MediatR;
using System.Collections.Generic;

namespace UltimateSolutions.Application.Commands.Invoice
{
    public class CreateInvoiceCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
        public double Gtotal { get; set; }

        public List<DetailsForCreateDto> InvoiceDetails { get; set; }
    }
}