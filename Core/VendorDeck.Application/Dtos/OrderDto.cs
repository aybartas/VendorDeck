using System.Text.Json.Serialization;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Dtos
{
    public class OrderDto
    {
        [JsonPropertyName("saveAddress")]
        public bool SaveAddress { get; set; }

        [JsonPropertyName("buyerId")]
        public string? BuyerId { get; set; }

        [JsonPropertyName("shippingAddress")]
        public ShippingAddress ShippingAddress { get; set; }

        [JsonPropertyName("deliveryFee")]
        public decimal DeliveryFee { get; set; }

        [JsonPropertyName("payment")]
        public PaymentDto Payment { get; set; }

    }
}
