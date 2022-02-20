using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateSolutions.Application.Queries.Product.GetAllProducts;

namespace UltimateSolutions.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Convention
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<IReadOnlyList<ProductForReturnDto>>> GetAllProduct()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return products.ToList();
        }
    }
}