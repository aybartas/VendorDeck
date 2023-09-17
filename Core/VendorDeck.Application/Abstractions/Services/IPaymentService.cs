using VendorDeck.Application.Dtos;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Abstractions.Services
{
    public interface IPaymentService
    {
        Task<PaymentIntentDto> SavePayment(Basket basket);
        PaymentIntentDto GetPaymentFromStripeResponse(string response, string stripeSigniture);
    }
}
