using MediatR;
using VendorDeck.Application.Dtos;

namespace VendorDeck.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public OrderDto Order { get; set; }
    }
}