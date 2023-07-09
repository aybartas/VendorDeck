using AutoMapper;
using MediatR;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Repositories;
using VendorDeck.Application.Responses;
using BasketEntity = VendorDeck.Domain.Entities.Concrete.Basket;

namespace VendorDeck.Application.Features.Commands.Basket.RemoveItemFromBasket
{
    public class RemoveItemFromBasketHandler : IRequestHandler<RemoveItemFromBasketRequest, RemoveItemFromBasketResponse>
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public RemoveItemFromBasketHandler(IMapper mapper, IBasketService basketService)
        {
            _mapper = mapper;
            _basketService = basketService;
        }

        public async Task<RemoveItemFromBasketResponse> Handle(RemoveItemFromBasketRequest request, CancellationToken cancellationToken = default)
        {
            var removeItemResponse = await _basketService.RemoveItemFromBasket(request.BuyerId, request.ProductId, request.Quantity);
            var response = _mapper.Map<RemoveItemFromBasketResponse>(removeItemResponse);
            return response;

        }
    }
}
