using MediatR;

namespace VendorDeck.Application.Features.Queries.User.GetCurrentUser
{
    public class GetCurrentUserQueryRequest : IRequest<GetCurrentUserQueryResponse>
    {
        public string Username { get; set; }
    }
}
