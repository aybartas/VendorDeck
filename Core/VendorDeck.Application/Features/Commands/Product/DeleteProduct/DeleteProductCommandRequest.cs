using MediatR;
using VendorDeck.Application.Dtos;

namespace VendorDeck.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public int ProductId { get; set; }
    }
}
