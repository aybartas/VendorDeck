using VendorDeck.Application.Responses;
using ProductEntity = VendorDeck.Domain.Entities.Concrete.Product;

namespace VendorDeck.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryResponse : PaginationBaseResponse<ProductEntity>
    {
    }
}
