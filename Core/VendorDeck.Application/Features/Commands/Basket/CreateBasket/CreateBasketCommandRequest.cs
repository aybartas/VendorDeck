using MediatR;
using BasketEntity = VendorDeck.Domain.Entities.Concrete.Basket;

namespace VendorDeck.Application.Features.Commands.Basket.CreateBasket
{
    public class CreateBasketCommandRequest : IRequest<CreateBasketCommandResponse>
    {
        public BasketEntity Basket { get; set; }
    }
}
