using MediatR;
using System.Collections.Generic;

namespace UltimateSolutions.Application.Queries.Product.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IReadOnlyList<ProductForReturnDto>>
    {
    }
}