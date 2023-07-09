using MediatR;
using VendorDeck.Application.Abstractions.Services;

namespace VendorDeck.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderService _orderService;

        public CreateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderService.CreateOrder(request.Order);

            return new CreateOrderCommandResponse
            {
                IsSuccess = true,
            };
        }
    }
}
