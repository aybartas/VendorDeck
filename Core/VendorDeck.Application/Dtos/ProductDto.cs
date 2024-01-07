using Microsoft.AspNetCore.Http;

namespace VendorDeck.Application.Dtos
{
    public class ProductDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile? File { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
    }
}
