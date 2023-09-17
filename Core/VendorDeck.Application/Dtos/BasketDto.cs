namespace VendorDeck.Application.Dtos
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public string PaymentIntentId { get; set; }
        public string ClientSecret { get; set; }
        public List<BasketItemDto> BasketItems { get; set; } = new();
    }
}
