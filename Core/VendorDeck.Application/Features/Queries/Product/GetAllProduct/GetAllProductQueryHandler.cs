using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Repositories;
using VendorDeck.Application.RequestParameters;
using VendorDeck.Application.Responses;

namespace VendorDeck.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductReadRepository productReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            this.productReadRepository = productReadRepository;
        }
        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = productReadRepository.GetAll().Count();

            var query = productReadRepository.GetAll(false);
            query = request.ApplyPagination(query);
            query = request.ApplySorting(query);

            return new GetAllProductQueryResponse
            {
                Items= query.ToList(),
                TotalCount = totalCount
            };
        }
    }
}
