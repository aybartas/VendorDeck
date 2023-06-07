using VendorDeck.Domain.Entities.Concrete;
using VendorDeck.Domain.Enums;

namespace VendorDeck.Application.ViewModels
{
    public class OrderViewModel
    {
        public string BuyerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DeliveryFee { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public ShippingAddress ShippingAddress { get; set; }
        public decimal Total { get; set; }
    }
}
