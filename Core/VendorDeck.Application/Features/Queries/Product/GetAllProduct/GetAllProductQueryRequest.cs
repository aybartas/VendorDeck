using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.RequestParameters;
using VendorDeck.Domain.Entities.Concrete;
using ProductEntity = VendorDeck.Domain.Entities.Concrete.Product;

namespace VendorDeck.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryRequest : IPagination<ProductEntity>,ISortable<ProductEntity>, IRequest<GetAllProductQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 10;
        public bool Ascending { get; set; } = true;
        public string SortBy { get; set; }

        public IQueryable<ProductEntity> ApplyPagination(IQueryable<ProductEntity> query)
        {
            return query.Skip(Size * Page).Take(Size);
        }

        public IQueryable<ProductEntity> ApplySorting(IQueryable<ProductEntity> query)
        {
            if (string.IsNullOrEmpty(SortBy)) return query;

            return SortBy switch
            {
                "price" => Ascending ? query.OrderBy(I => I.Price) : query.OrderByDescending(I => I.Price),
                "name" => Ascending ? query.OrderBy(I => I.Name) : query.OrderByDescending(I => I.Name),
                _ => query,
            };
        }
    }
}
