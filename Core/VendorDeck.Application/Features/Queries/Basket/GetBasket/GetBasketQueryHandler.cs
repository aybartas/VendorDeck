using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Repositories;

namespace VendorDeck.Application.Features.Queries.Basket.GetBasket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQueryRequest, GetBasketQueryResponse>
    {
        private readonly IBasketReadRepository _basketReadRepository;

        public GetBasketQueryHandler(IBasketReadRepository basketReadRepository)
        {
            _basketReadRepository = basketReadRepository;
        }

        public async Task<GetBasketQueryResponse> Handle(GetBasketQueryRequest request, CancellationToken cancellationToken)
        {
            var basket = await _basketReadRepository.GetSingleAsync(I => I.BuyerId == request.BuyerId.ToString());

            return new GetBasketQueryResponse { Basket = basket };
        }
    }
}
