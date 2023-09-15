namespace VendorDeck.Application.Dtos
{
    public class PaymentIntentDto
    {
        public string PaymentIntentId { get; set; }
        public string ClientSecret { get; set; }
        public bool Successs { get; set; }

    }
}
