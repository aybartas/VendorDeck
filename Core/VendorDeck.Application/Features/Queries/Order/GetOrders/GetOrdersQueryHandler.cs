
using MediatR;
using Microsoft.EntityFrameworkCore;
using VendorDeck.Application.Repositories;

namespace VendorDeck.Application.Features.Queries.Order.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQueryRequest, GetOrdersQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public GetOrdersQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }
        public async Task<GetOrdersQueryResponse> Handle(GetOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await  _orderReadRepository.GetAllOrders().ToListAsync();
            var response = new GetOrdersQueryResponse
            {
                Orders = orders
            };

            return response;
        }
    }
}
