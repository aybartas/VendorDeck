namespace VendorDeck.API.Models
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
    }
}
