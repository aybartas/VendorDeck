using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Dtos;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandRequest: IRequest<AddItemToBasketCommandResponse>
    {
        public BasketDto Basket { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
