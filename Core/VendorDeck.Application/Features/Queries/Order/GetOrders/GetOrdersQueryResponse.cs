
using VendorDeck.Application.ViewModels;

namespace VendorDeck.Application.Features.Queries.Order.GetOrders
{
    public class GetOrdersQueryResponse
    {
        public List<OrderViewModel> Orders { get; set; }
        public int TotalCount { get; set; }

    }
}
