using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateSolutions.Application.Queries.Customer.GetAllCustomers;

namespace UltimateSolutions.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Convention
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCustomers")]
        public async Task<ActionResult<IReadOnlyList<CustomerForReturnDto>>> GetAllCustomers()
        {
            var customer = await _mediator.Send(new GetAllCustomersQuery());
            return customer.ToList();
        }
    }
}