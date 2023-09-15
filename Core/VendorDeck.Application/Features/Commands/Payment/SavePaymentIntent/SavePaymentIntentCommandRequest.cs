using MediatR;
using VendorDeck.Application.Dtos;

namespace VendorDeck.Application.Features.Commands.Payment.CreatePaymentIntent
{
    public class CreatePaymentIntentCommandRequest : IRequest<CreatePaymentIntentCommandResponse>
    {
        public string UserName { get; set; }
    }
}