using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Responses;

namespace VendorDeck.Application.Features.Commands.Basket.RemoveItemFromBasket
{
    public class RemoveItemFromBasketResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new();

    }
}
