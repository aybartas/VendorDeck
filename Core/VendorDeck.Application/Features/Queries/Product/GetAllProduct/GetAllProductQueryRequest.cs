using MediatR;
using System.ComponentModel;
using VendorDeck.Application.RequestParameters;
using ProductEntity = VendorDeck.Domain.Entities.Concrete.Product;

namespace VendorDeck.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryRequest : IProductParams, IPageable<ProductEntity>,ISortable<ProductEntity>, IRequest<GetAllProductQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 6;
        public bool Ascending { get; set; } = true;
        public string? SortBy { get; set; }
        public string? SearchText { get; set; }
        public string? Brands { get; set; }
        public string? Types { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

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

        public IQueryable<ProductEntity> ApplyFiltering(IQueryable<ProductEntity> query)
        {
            if (!string.IsNullOrEmpty(SearchText))
                query = query.Where(x => x.Name.Contains(SearchText));

            if (!string.IsNullOrEmpty(Brands))
            {
                var brandsList = Brands.Split(',').ToList();
                query = query.Where(x => brandsList.Any(y => x.Brand == y));
            }
            if (!string.IsNullOrEmpty(Types))
            {
                var typeList = Types.Split(',').ToList();
                query = query.Where(x => typeList.Any(y => x.Type == y));
            }

            if(MinPrice.HasValue)
                query = query.Where(x => x.Price >= MinPrice.Value);

            if (MaxPrice.HasValue)
                query = query.Where(x => x.Price <= MaxPrice.Value);

            return query;
        }

    }
}
