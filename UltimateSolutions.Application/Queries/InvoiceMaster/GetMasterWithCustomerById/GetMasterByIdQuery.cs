using MediatR;

namespace UltimateSolutions.Application.Queries.InvoiceMaster.GetMasterWithCustomerById
{
    public class GetMasterByIdQuery : IRequest<InvoiceMasterForReturnDto>
    {
        public int MasterId { get; set; }
    }
}