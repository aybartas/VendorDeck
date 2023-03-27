using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Domain.Entities.Concrete;
using BasketEntity = VendorDeck.Domain.Entities.Concrete.Basket;

namespace VendorDeck.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandRequest: IRequest<AddItemToBasketCommandResponse>
    {
        public BasketEntity Basket { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
