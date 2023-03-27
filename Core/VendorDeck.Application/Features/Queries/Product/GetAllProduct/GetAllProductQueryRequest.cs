using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.RequestParameters;

namespace VendorDeck.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryRequest : Pagination, IRequest<GetAllProductQueryResponse>  
    {
    }
}
