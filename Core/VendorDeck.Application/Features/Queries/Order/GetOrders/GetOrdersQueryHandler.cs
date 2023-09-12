
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VendorDeck.Application.Repositories;
using VendorDeck.Application.ViewModels;

namespace VendorDeck.Application.Features.Queries.Order.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQueryRequest, GetOrdersQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IOrderReadRepository orderReadRepository, IMapper mapper)
        {
            _orderReadRepository = orderReadRepository;
            _mapper = mapper;
        }
        public async Task<GetOrdersQueryResponse> Handle(GetOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var orderList = await  _orderReadRepository.GetAllOrders(order => order.BuyerId == request.UserName).ToListAsync();
            var orders = _mapper.Map<List<OrderViewModel>>(orderList);
            var response = new GetOrdersQueryResponse
            {
                Orders = orders
            };

            return response;
        }
    }
}
