
using BasketEntity = VendorDeck.Domain.Entities.Concrete.Basket;

namespace VendorDeck.Application.Features.Queries.Basket.GetBasket
{
    public class GetBasketQueryResponse
    {
        public BasketEntity Basket { get; set; }
    }
}
