using MediatR;

namespace VendorDeck.Application.Features.Commands.Payment.ProcessPayment
{
    public class ProcessPaymentCommandRequest : IRequest<ProcessPaymentCommandResponse>
    {
        public string StripeResponse { get; set; }
        public string StripeSigniture { get; set; }
    }
}
