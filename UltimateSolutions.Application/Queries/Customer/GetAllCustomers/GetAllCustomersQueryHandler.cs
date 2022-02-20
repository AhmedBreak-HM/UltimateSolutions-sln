using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UltimateSolutions.Application.Contracts;

namespace UltimateSolutions.Application.Queries.Customer.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IReadOnlyList<CustomerForReturnDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CustomerForReturnDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<CustomerForReturnDto>>(customer);
        }
    }
}