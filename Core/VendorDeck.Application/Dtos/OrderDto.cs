using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Dtos
{
    public class OrderDto
    {
        public bool SaveAddress { get; set; }
        public string BuyerId { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public decimal DeliveryFee { get; set; }

    }
}
