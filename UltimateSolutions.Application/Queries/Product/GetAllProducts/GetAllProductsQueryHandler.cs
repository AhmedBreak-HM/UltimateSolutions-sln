using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UltimateSolutions.Application.Contracts;

namespace UltimateSolutions.Application.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyList<ProductForReturnDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPorductRepository _porductRepository;

        public GetAllProductsQueryHandler(IMapper mapper, IPorductRepository porductRepository)
        {
            _mapper = mapper;
            _porductRepository = porductRepository;
        }

        public async Task<IReadOnlyList<ProductForReturnDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _porductRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<ProductForReturnDto>>(products);
        }
    }
}