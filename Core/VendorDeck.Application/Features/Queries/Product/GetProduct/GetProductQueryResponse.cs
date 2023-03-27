using ProductEntity = VendorDeck.Domain.Entities.Concrete.Product;

namespace VendorDeck.Application.Features.Queries.Product.GetProduct
{
    public class GetProductQueryResponse
    {
        public ProductEntity Product { get; set; }
    }
}
