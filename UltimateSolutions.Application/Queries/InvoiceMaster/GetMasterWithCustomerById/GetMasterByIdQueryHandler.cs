using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UltimateSolutions.Application.Contracts;

namespace UltimateSolutions.Application.Queries.InvoiceMaster.GetMasterWithCustomerById
{
    public class GetMasterByIdQueryHandler : IRequestHandler<GetMasterByIdQuery, InvoiceMasterForReturnDto>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public GetMasterByIdQueryHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<InvoiceMasterForReturnDto> Handle(GetMasterByIdQuery request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.GetMasterWithCustomerById(request.MasterId);
        }
    }
}