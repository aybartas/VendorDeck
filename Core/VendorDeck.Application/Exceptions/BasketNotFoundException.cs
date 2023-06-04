namespace VendorDeck.Application.Exceptions
{
    public class BasketNotFoundException :Exception
    {
        public BasketNotFoundException(string buyerId) : base($"Basket with buyer id {buyerId} not found ")
        {
            
        }
    }
}
