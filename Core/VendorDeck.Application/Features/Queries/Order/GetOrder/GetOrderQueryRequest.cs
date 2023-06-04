using MediatR;

namespace VendorDeck.Application.Features.Queries.Order.GetOrder
{
    public class GetOrderQueryRequest : IRequest<GetOrderQueryResponse>
    {
        public string Username { get; set; }
        public int Id { get; set; }
    }
}
