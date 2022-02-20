using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UltimateSolutions.Application.Commands.Invoice;
using UltimateSolutions.Application.Queries.InvoiceMaster.GetMasterWithCustomerById;

namespace UltimateSolutions.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetMasterById/{id}")]
        public async Task<ActionResult<InvoiceMasterForReturnDto>> GetMasterById(int id)
        {
            return await _mediator.Send(new GetMasterByIdQuery() { MasterId = id });
        }

        [HttpPost("CreateInvoice")]
        public async Task<ActionResult<int>> CreateMasterDetials(CreateInvoiceCommand createInvoiceCommand)
        {
            var newInvoiceId = await _mediator.Send(createInvoiceCommand);
            return CreatedAtAction("GetMasterById", new { controller = "Invoice", id = newInvoiceId }, newInvoiceId);
        }
    }
}