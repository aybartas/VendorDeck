using MediatR;
using BasketEntity = VendorDeck.Domain.Entities.Concrete.Basket;

namespace VendorDeck.Application.Features.Commands.Basket.RemoveItemFromBasket
{
    public class RemoveItemFromBasketRequest : IRequest<RemoveItemFromBasketResponse>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public BasketEntity Basket { get; set; }
    }
}
