namespace VendorDeck.Domain.Entities.Concrete
{
    public class Address :BaseEntity
    {
        public string Details { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
