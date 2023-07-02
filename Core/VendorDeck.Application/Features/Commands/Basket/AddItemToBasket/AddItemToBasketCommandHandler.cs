using AutoMapper;
using MediatR;
using VendorDeck.Application.Repositories;
using BasketEntity = VendorDeck.Domain.Entities.Concrete.Basket;

namespace VendorDeck.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
    {
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IMapper _mapper;

        public AddItemToBasketCommandHandler(IBasketWriteRepository basketWriteRepository, IMapper mapper)
        {
            _basketWriteRepository = basketWriteRepository;
            _mapper = mapper;
        }
        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken = default)
        {

            var result = new AddItemToBasketCommandResponse { Success = true };
            var basket = _mapper.Map<BasketEntity>(request.Basket);

            try
            {
                await _basketWriteRepository.AddItemToBasket(basket, request.Product, request.Quantity);
            }
            catch (Exception)
            {

                result.Success = false;
            }
            return result;
        }
    }
}
