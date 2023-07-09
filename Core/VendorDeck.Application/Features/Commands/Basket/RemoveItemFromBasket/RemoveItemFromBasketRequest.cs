using MediatR;
using VendorDeck.Application.Dtos;

namespace VendorDeck.Application.Features.Commands.Basket.RemoveItemFromBasket
{
    public class RemoveItemFromBasketRequest : IRequest<RemoveItemFromBasketResponse>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string BuyerId { get; set; }
    }
}
