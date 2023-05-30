using MediatR;
using VendorDeck.Application.Repositories;

namespace VendorDeck.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
    {
        private readonly IBasketWriteRepository _basketWriteRepository;

        public AddItemToBasketCommandHandler(IBasketWriteRepository basketWriteRepository)
        {
            _basketWriteRepository = basketWriteRepository;
        }
        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken = default)
        {
            var result = new AddItemToBasketCommandResponse { Success = true };
            try
            {
                await _basketWriteRepository.AddItemToBasket(request.Basket, request.Product, request.Quantity);
            }
            catch (Exception)
            {

                result.Success= false;
            }            
            return result;
        }
    }
}
