using MediatR;
using VendorDeck.Application.Repositories;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Features.Commands.Basket.RemoveItemFromBasket
{
    public class RemoveItemFromBasketHandler : IRequestHandler<RemoveItemFromBasketRequest, RemoveItemFromBasketResponse>
    {
        private readonly IBasketWriteRepository _basketWriteRepository;
        public RemoveItemFromBasketHandler(IBasketWriteRepository basketWriteRepository)
        {
            _basketWriteRepository = basketWriteRepository;
        }

        public async Task<RemoveItemFromBasketResponse> Handle(RemoveItemFromBasketRequest request, CancellationToken cancellationToken = default)
        {
            var removeBasketItemResponse = new RemoveItemFromBasketResponse { Success = true };
            await _basketWriteRepository.RemoveItemFromBasket(request.Basket,request.ProductId, request.Quantity);
            return removeBasketItemResponse;
        }
    }
}
