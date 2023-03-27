using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Features.Queries.Basket.GetBasket
{
    public class GetBasketQueryRequest : IRequest<GetBasketQueryResponse>
    {
        public string BuyerId { get; set; }
        public bool IncludeItems { get; set; } = true;
    }
}
