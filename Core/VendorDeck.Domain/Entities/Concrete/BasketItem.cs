using System.Text.Json.Serialization;

namespace VendorDeck.Domain.Entities.Concrete
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        // navigation properties
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}