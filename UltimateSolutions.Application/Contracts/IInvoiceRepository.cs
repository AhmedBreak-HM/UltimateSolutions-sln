using System.Threading.Tasks;
using UltimateSolutions.Application.Commands.Invoice;
using UltimateSolutions.Application.Queries.InvoiceMaster.GetMasterWithCustomerById;
using UltimateSolutions.Domain.Models;
using UltimateSolutions.Domain.SeedWork;

namespace UltimateSolutions.Application.Contracts
{
    public interface IInvoiceRepository : IAsyncRepository<InvoiceMaster>
    {
        Task<int> CreateInvoice(CreateInvoiceCommand createInvoiceCommand);

        Task<InvoiceMasterForReturnDto> GetMasterWithCustomerById(int id);
    }
}