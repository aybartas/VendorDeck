

using AutoMapper;
using MediatR;
using VendorDeck.Application.Repositories;
using VendorDeck.Application.ViewModels;

namespace VendorDeck.Application.Features.Queries.Order.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryRequest, GetOrderQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IMapper _mapper;
        public GetOrderQueryHandler(IOrderReadRepository orderReadRepository, IMapper mapper)
        {
            _orderReadRepository = orderReadRepository;
            _mapper = mapper;
        }
        public async Task<GetOrderQueryResponse> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderReadRepository.GetSingleAsync(I => I.BuyerId == request.Username && I.Id == request.Id);

            var orderModel = _mapper.Map<OrderViewModel>(order);

            var response = new GetOrderQueryResponse
            {
                Order = orderModel
            };

            return response;
        }
    }
}
