using AutoMapper;
using MediatR;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Repositories;
using BasketEntity = VendorDeck.Domain.Entities.Concrete.Basket;

namespace VendorDeck.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
    {
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public AddItemToBasketCommandHandler(IBasketWriteRepository basketWriteRepository, IMapper mapper, IBasketService basketService)
        {
            _basketWriteRepository = basketWriteRepository;
            _mapper = mapper;
            _basketService = basketService;
        }
        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken = default)
        {
            var result = new AddItemToBasketCommandResponse { Success = true };

            try
            {
                await _basketService.AddItemToBasket(request.BuyerId, request.ProductId, request.Quantity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Errors.Add(ex.Message);
                return result;
            }
            return result;
        }
    }
}
