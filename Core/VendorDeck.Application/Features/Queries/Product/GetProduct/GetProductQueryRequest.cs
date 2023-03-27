using MediatR;

namespace VendorDeck.Application.Features.Queries.Product.GetProduct
{
    public class GetProductQueryRequest : IRequest<GetProductQueryResponse>
    {
        public int ProductId { get; set; }
    }
}
