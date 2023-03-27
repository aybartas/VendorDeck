using MediatR;
using VendorDeck.Application.Repositories;

namespace VendorDeck.Application.Features.Queries.Product.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, GetProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;

        public GetProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }
        public async Task<GetProductQueryResponse> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.ProductId);
            return new GetProductQueryResponse { Product = product };
        }
    }
}
