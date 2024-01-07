namespace VendorDeck.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int ProductId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
