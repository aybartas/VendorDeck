using MediatR;
using Microsoft.EntityFrameworkCore;
using VendorDeck.Application.Repositories;

namespace VendorDeck.Application.Features.Queries.Product.GetProductFilterValues
{
    public class GetProductsFilterValuesQueryHandler : IRequestHandler<GetProductsFilterValuesRequest, GetProductsFilterValuesResponse>
    {
        private readonly IProductReadRepository _productReadRepository;

        public GetProductsFilterValuesQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetProductsFilterValuesResponse> Handle(GetProductsFilterValuesRequest request, CancellationToken cancellationToken)
        {
            var products = await _productReadRepository.GetAll(useTracking: false).ToListAsync();

            var brands = products.Select(I => I.Brand).Distinct()?.ToList();
            var types = products.Select(I => I.Type).Distinct()?.ToList();
            var minPrice = products.Min(I => I.Price);
            var maxPrice = products.Max(I => I.Price);

            var result = new GetProductsFilterValuesResponse
            {
                Brands = brands,
                Types = types,
                MinPrice = minPrice,
                MaxPrice = maxPrice
            };

            return result;
        }

    }
}
