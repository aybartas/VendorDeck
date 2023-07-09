using MediatR;
using VendorDeck.Application.Dtos;
using VendorDeck.Domain.Entities.Concrete;
namespace VendorDeck.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandRequest: IRequest<AddItemToBasketCommandResponse>
    {
        public string BuyerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
} 
  