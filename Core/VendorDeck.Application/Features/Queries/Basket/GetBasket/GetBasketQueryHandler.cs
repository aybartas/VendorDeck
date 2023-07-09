using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.Repositories;

namespace VendorDeck.Application.Features.Queries.Basket.GetBasket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQueryRequest, GetBasketQueryResponse>
    {
        private readonly IBasketReadRepository _basketReadRepository;
        private readonly IMapper _mapper;

        public GetBasketQueryHandler(IBasketReadRepository basketReadRepository, IMapper mapper)
        {
            _basketReadRepository = basketReadRepository;
            _mapper = mapper;
        }

        public async Task<GetBasketQueryResponse> Handle(GetBasketQueryRequest request, CancellationToken cancellationToken = default)
        {
            var basket = await _basketReadRepository.GetSingleAsync(I => I.BuyerId == request.BuyerId.ToString());
            var basketDto = _mapper.Map<BasketDto>(basket);
           
            return new GetBasketQueryResponse { Basket = basketDto };
        }
    }
}
