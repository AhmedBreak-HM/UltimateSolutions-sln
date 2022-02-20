using MediatR;
using System.Collections.Generic;

namespace UltimateSolutions.Application.Queries.Customer.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<IReadOnlyList<CustomerForReturnDto>>
    {
    }
}