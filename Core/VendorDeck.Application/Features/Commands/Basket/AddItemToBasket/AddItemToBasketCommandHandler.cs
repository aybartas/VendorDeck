using AutoMapper;
using MediatR;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Repositories;

namespace VendorDeck.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        private readonly IBasketReadRepository _basketReadRepository;

        public AddItemToBasketCommandHandler(IMapper mapper, IBasketService basketService, IBasketReadRepository basketReadRepository)
        {
            _mapper = mapper;
            _basketService = basketService;
            _basketReadRepository = basketReadRepository;
        }
        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken = default)
        {
            var result = new AddItemToBasketCommandResponse { Success = true };

            var basket = await _basketReadRepository.GetSingleAsync(I => I.BuyerId == request.BuyerId);
            var isNewBuyerIdNeeded = string.IsNullOrEmpty(request.BuyerId);

            if (isNewBuyerIdNeeded || basket is null)
            {
                var buyerId = isNewBuyerIdNeeded ?  Guid.NewGuid().ToString() : request.BuyerId;
              
                await _basketService.CreateNewBasket(buyerId);

                if (isNewBuyerIdNeeded)
                {
                    result.NewBuyerId = buyerId;
                    result.SetNewBuyerId = true;
                }
            }

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
