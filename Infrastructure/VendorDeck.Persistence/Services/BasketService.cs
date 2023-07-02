using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Repositories;
using VendorDeck.Application.Responses;

namespace VendorDeck.Persistence.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IBasketReadRepository _basketReadRepository;

        public BasketService(IBasketWriteRepository basketWriteRepository, IProductReadRepository productReadRepository, IBasketReadRepository basketReadRepository)
        {
            _basketWriteRepository = basketWriteRepository;
            _productReadRepository = productReadRepository;
            _basketReadRepository = basketReadRepository;
        }

        public async Task<BaseResponse> AddItemToBasket(string buyerId, int productId, int quantity)
        {
            var response = new BaseResponse();

            var product = await _productReadRepository.GetByIdAsync(productId);

            if (product is null)
            {
                response.Success = false;
                response.Errors.Add($"Product with id {productId} not found");
                return response;
            }

            var basket = await _basketReadRepository.GetSingleAsync(I => I.BuyerId == buyerId);

            if (basket is null)
            {
                response.Success = false;
                response.Errors.Add($"Basket with buyer id {buyerId}");
                return response;
            }

            await _basketWriteRepository.AddItemToBasket(basket, product, quantity);

            return response;
        }


        public async Task<BaseResponse> RemoveItemFromBasket(string buyerId, int productId, int quantity)
        {
            var response = new BaseResponse();

            var basket = await _basketReadRepository.GetSingleAsync(I => I.BuyerId == buyerId);

            if (basket is null)
            {
                response.Success = false;
                response.Errors.Add($"Basket with buyer id {buyerId}");
                return response;
            }

            await _basketWriteRepository.RemoveItemFromBasket(basket, productId, quantity);

            return response;
        }
    }
}
