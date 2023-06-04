using OrderModel = VendorDeck.Domain.Entities.Concrete.Order;

namespace VendorDeck.Application.Features.Queries.Order.GetOrders
{
    public class GetOrdersQueryResponse
    {
        public List<OrderModel> Orders { get; set; }
        public int TotalCount { get; set; }

    }
}
