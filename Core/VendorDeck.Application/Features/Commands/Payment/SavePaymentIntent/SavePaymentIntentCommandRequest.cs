using MediatR;

namespace VendorDeck.Application.Features.Commands.Payment.CreatePaymentIntent
{
    public class SavePaymentIntentCommandRequest : IRequest<SavePaymentIntentCommandResponse>
    {
        public string UserName { get; set; }
    }
}