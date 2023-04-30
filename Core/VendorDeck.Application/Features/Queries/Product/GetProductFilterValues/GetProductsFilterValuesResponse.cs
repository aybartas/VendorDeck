using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Repositories;

namespace VendorDeck.Application.Features.Queries.Product.GetProductFilterValues
{
    public class GetProductsFilterValuesResponse
    {
        public List<string> Brands { get; set; }
        public List<string> Types { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

    }
}
