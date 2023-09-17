using VendorDeck.Domain.Entities.Interfaces;
using VendorDeck.Domain.Enums;

namespace VendorDeck.Domain.Entities.Concrete
{
    public class Order : BaseEntity , ITable
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
        public string PaymentIntentId { get; set; }

    }
}
