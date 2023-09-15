using VendorDeck.Application.Dtos;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Abstractions.Services
{
    public interface IPaymentService
    {
        public Task<PaymentIntentDto> SavePayment(Basket basket);

    }
}
