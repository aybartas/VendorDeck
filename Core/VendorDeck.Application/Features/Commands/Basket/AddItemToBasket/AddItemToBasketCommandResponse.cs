using VendorDeck.Application.Responses;
namespace VendorDeck.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandResponse : BaseResponse
    {
        public bool Success { get; set; }
        public bool SetNewBuyerId { get; set; }
        public string NewBuyerId { get; set; }

    }
}
