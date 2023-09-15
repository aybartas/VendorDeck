using VendorDeck.Application.Dtos;
using VendorDeck.Application.Responses;

namespace VendorDeck.Application.Features.Commands.Payment.CreatePaymentIntent
{
    public class SavePaymentIntentCommandResponse : BaseResponse
    {
        public BasketDto Basket { get; set; }
    }
}