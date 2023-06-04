

using MediatR;
using VendorDeck.Application.Repositories;

namespace VendorDeck.Application.Features.Queries.Order.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryRequest, GetOrderQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public GetOrderQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }
        public async Task<GetOrderQueryResponse> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderReadRepository.GetSingleAsync(I => I.BuyerId == request.Username && I.Id == request.Id);
            
            var response = new GetOrderQueryResponse
            {
                Order = order
            };

            return response;
        }
    }
}
