using VendorDeck.Domain.Entities.Interfaces;

namespace VendorDeck.Domain.Entities.Concrete
{
    public class OrderItem : BaseEntity,ITable
    {
        public OrderedProductItem OrderedProductItem { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
