namespace VendorDeck.Application.Dtos
{
    public class PaymentDto
    {
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpDate { get; set; }
        public bool SavePayment { get; set; }

    }
}
