namespace VendorDeck.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int OrderNumber { get; set; }
        public string ErrorMessage { get; set; }
    }
}