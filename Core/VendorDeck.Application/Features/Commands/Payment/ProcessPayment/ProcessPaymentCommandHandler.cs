using MediatR;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Repositories;
using VendorDeck.Domain.Enums;

namespace VendorDeck.Application.Features.Commands.Payment.ProcessPayment
{
    public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommandRequest, ProcessPaymentCommandResponse>
    {
        private readonly IPaymentService _paymentService;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;

        public ProcessPaymentCommandHandler(IPaymentService paymentService, IOrderReadRepository orderReadRepository, IOrderService orderService, IOrderWriteRepository orderWriteRepository)
        {
            _paymentService = paymentService;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }
        public async Task<ProcessPaymentCommandResponse> Handle(ProcessPaymentCommandRequest request, CancellationToken cancellationToken)
        {
            var payment =  _paymentService.GetPaymentFromStripeResponse(request.StripeResponse,request.StripeSigniture);
            var order = await _orderReadRepository.GetSingleAsync(x => x.PaymentIntentId == payment.PaymentIntentId);

            order.OrderStatus = payment.Successs ? OrderStatus.PaymentReceived : OrderStatus.PaymentFailed;

            _orderWriteRepository.Update(order);
            await _orderWriteRepository.SaveAsync();

            return new ProcessPaymentCommandResponse { Success = payment.Successs };
        }
    }
}
