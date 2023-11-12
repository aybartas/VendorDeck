using MediatR;
using VendorDeck.Application.Dtos;

namespace VendorDeck.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public ProductDto Product { get; set; }
    }
}
