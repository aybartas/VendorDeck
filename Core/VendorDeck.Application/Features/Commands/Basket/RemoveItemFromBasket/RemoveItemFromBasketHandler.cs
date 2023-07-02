using AutoMapper;
using MediatR;
using VendorDeck.Application.Repositories;
using VendorDeck.Domain.Entities.Concrete;
using BasketEntity = VendorDeck.Domain.Entities.Concrete.Basket;

namespace VendorDeck.Application.Features.Commands.Basket.RemoveItemFromBasket
{
    public class RemoveItemFromBasketHandler : IRequestHandler<RemoveItemFromBasketRequest, RemoveItemFromBasketResponse>
    {
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IMapper _mapper;

        public RemoveItemFromBasketHandler(IBasketWriteRepository basketWriteRepository, IMapper mapper)
        {
            _basketWriteRepository = basketWriteRepository;
            _mapper = mapper;
        }

        public async Task<RemoveItemFromBasketResponse> Handle(RemoveItemFromBasketRequest request, CancellationToken cancellationToken = default)
        {
            var removeBasketItemResponse = new RemoveItemFromBasketResponse { Success = true };

            var basketEntity = _mapper.Map<BasketEntity>(request.Basket);

            await _basketWriteRepository.RemoveItemFromBasket(basketEntity, request.ProductId, request.Quantity);
            return removeBasketItemResponse;
        }
    }
}
