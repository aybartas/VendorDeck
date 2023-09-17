using AutoMapper;
using MediatR;
using VendorDeck.Application.Abstractions.Services;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.Repositories;

namespace VendorDeck.Application.Features.Commands.Payment.CreatePaymentIntent
{
    public class SavePaymentIntentCommandHandler : IRequestHandler<SavePaymentIntentCommandRequest, SavePaymentIntentCommandResponse>
    {
        private readonly IPaymentService _paymentService;
        private readonly IBasketReadRepository _basketReadRepository;
        private readonly IMapper _mapper;
        private readonly IBasketWriteRepository _basketWriteRepository;

        public SavePaymentIntentCommandHandler(IPaymentService paymentService, IBasketReadRepository basketReadRepository, IMapper mapper, IBasketWriteRepository basketWriteRepository)
        {
            _paymentService = paymentService;
            _basketReadRepository = basketReadRepository;
            _mapper = mapper;
            _basketWriteRepository = basketWriteRepository;
        }
        public async Task<SavePaymentIntentCommandResponse> Handle(SavePaymentIntentCommandRequest request, CancellationToken cancellationToken)
        {
            var basket = await _basketReadRepository.GetSingleAsync(I => I.BuyerId == request.UserName.ToString());
            var saveResponse = await _paymentService.SavePayment(basket);

            if (saveResponse.Successs)
            {
                basket.ClientSecret = saveResponse.ClientSecret;
                basket.PaymentIntentId = saveResponse.PaymentIntentId;

                 _basketWriteRepository.Update(basket);
                await _basketWriteRepository.SaveAsync();
            }

            var basketDto = _mapper.Map<BasketDto>(basket);

            return new SavePaymentIntentCommandResponse
            {
                Success = saveResponse.Successs,
                Basket = basketDto,
            };
        }
    }
}
