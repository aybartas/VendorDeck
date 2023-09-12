using MediatR;

namespace VendorDeck.Application.Features.Queries.Order.GetOrders
{
    public class GetOrdersQueryRequest : IRequest<GetOrdersQueryResponse>
    {
        public string UserName { get; set; }
    }
}
