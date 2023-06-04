using OrderModel = VendorDeck.Domain.Entities.Concrete.Order;

namespace VendorDeck.Application.Features.Queries.Order.GetOrder
{
    public class GetOrderQueryResponse
    {
         public OrderModel Order { get; set; }
    }
}
