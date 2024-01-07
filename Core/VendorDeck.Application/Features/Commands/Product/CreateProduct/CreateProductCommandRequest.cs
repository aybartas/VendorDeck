using MediatR;
using VendorDeck.Application.Dtos;
using VendorDeck.Application.ViewModels;

namespace VendorDeck.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public ProductDto Product { get; set; }
    }
}
