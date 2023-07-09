using VendorDeck.Application.Responses;

namespace VendorDeck.Application.Abstractions.Services
{
    public interface IBasketService
    {
        Task<BaseResponse> AddItemToBasket(string buyerId, int productId, int quantity);
        Task<BaseResponse> RemoveItemFromBasket(string buyerId, int productId, int quantity);

    }
}
